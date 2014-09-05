using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using M = Manifold.Interop;
using System.IO;

namespace RunScriptOnDirChange
{
    public partial class GUI : UserControl, Manifold.Interop.Scripts.IEventsConnection
    {

        /// <summary>
        /// mapp
        /// </summary>
        protected M.Application mApp { get; set; }

        /// <summary>
        /// File system watcher instance
        /// </summary>
        protected FileSystemWatcher watcher { get; set; }

        /// <summary>
        /// name of a callback script to be executed on change
        /// </summary>
        protected string callbackScript { get; set; }

        public GUI()
        {
            InitializeComponent();
            txtDumpName.Text = watcherNotificationsComp;

            //dump some data to a variable, so it can be accessed from a non-ui thread
            cmbScripts.SelectedValueChanged += cmbScripts_SelectedValueChanged;
        }

        /// <summary>
        /// connect M events listeners
        /// </summary>
        /// <param name="ev"></param>
        public void ConnectEvents(Manifold.Interop.Scripts.Events ev)
        {
            //watch for doc cnahges
            ev.DocumentClosed += new Manifold.Interop.Scripts.Events.DocumentClosedEventHandler(DocumentChanged);
            ev.DocumentCreated += new Manifold.Interop.Scripts.Events.DocumentCreatedEventHandler(DocumentChanged);
            ev.DocumentOpened += new Manifold.Interop.Scripts.Events.DocumentOpenedEventHandler(DocumentChanged);
            ev.DocumentSaved += new Manifold.Interop.Scripts.Events.DocumentSavedEventHandler(DocumentChanged);
            ev.AddinLoaded += new Manifold.Interop.Scripts.Events.AddinLoadedEventHandler(DocumentChanged);


            //watch for component changes
            ev.ComponentsRemoved += ev_ComponentsRemoved;
            ev.ComponentsAdded += ev_ComponentsAdded;
            ev.ComponentNameChanged += ev_ComponentNameChanged;
        }

        /// <summary>
        /// cmbScripts_SelectedValueChanged callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmbScripts_SelectedValueChanged(object sender, EventArgs e)
        {
            callbackScript = cmbScripts.SelectedValue as string;
        }

        
        void ev_ComponentNameChanged(object sender, M.Scripts.ComponentEventArgs Args)
        {
            BindScriptsCombo();
        }

        void ev_ComponentsAdded(object sender, M.Scripts.DocumentEventArgs Args)
        {
            BindScriptsCombo();
        }

        void ev_ComponentsRemoved(object sender, M.Scripts.DocumentEventArgs Args)
        {
            BindScriptsCombo();
        }


        private string noScript = "Ignore callbacks...";

        /// <summary>
        /// loads available scripts to combobox
        /// </summary>
        private void BindScriptsCombo()
        {
            var comboData = new List<string>();
            comboData.Add(noScript);

            try //when closing document, this sometimes gets unhappy
            {
                if (mApp != null && mApp.ActiveDocument != null)
                {
                    foreach (M.Component c in mApp.ActiveDocument.ComponentSet)
                    {
                        if (c.Type == M.ComponentType.ComponentScript)
                        {
                            comboData.Add(c.Name);
                        }
                    }
                }
            }
            catch { }

            cmbScripts.DataSource = comboData;
        }

        /// <summary>
        /// doc changed callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DocumentChanged(System.Object sender, Manifold.Interop.Scripts.DocumentEventArgs args)
        {
            //grab a reference to the application
            if (args.Document != null)
            {
                mApp = args.Document.Application;
                BindScriptsCombo();
            }
            else
            {
                //this was doc close so just kill the watcher
                KillWatcher();
            }
        }


        /// <summary>
        /// Kills the directory watcher
        /// </summary>
        protected void KillWatcher()
        {
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false;

                watcher.Dispose();
                watcher = null;
            }
            //enable start btn and disable end
            btnStartWatcher.Enabled = true;
            btnStopWatcher.Enabled = false;

            chckBoxCreate.Enabled = true;
            chckBoxChange.Enabled = true;
            chckBoxDelete.Enabled = true;
        }

        /// <summary>
        /// Starts watching for directory changes
        /// </summary>
        protected void StartWatcher()
        {
            if (!Directory.Exists(txtDir.Text))
            {
                MessageBox.Show("Directory to watch does not exist");
                return;
            }

            if (cmbScripts.Items.Count == 0 || (string)cmbScripts.SelectedItem == noScript)
            {
                MessageBox.Show("No scripts to call");
                return;
            }

            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher();
            watcher.Path = txtDir.Text;

            //Watch for changes
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite;

            //watch for all changes
            watcher.Filter = "*.*";

            //react to file created / changed only
            if (chckBoxCreate.Checked)
            {
                watcher.Created += OnWatchedFileChanged;
            }

            if (chckBoxChange.Checked)
            {
                watcher.Changed += OnWatchedFileChanged;
                watcher.Renamed += OnWatchedFileChanged;
            }

            if (chckBoxDelete.Checked)
            {
                watcher.Deleted += OnWatchedFileChanged;
            }


            //disable start btn and enable end btn
            btnStartWatcher.Enabled = false;
            btnStopWatcher.Enabled = true;

            chckBoxCreate.Enabled = false;
            chckBoxChange.Enabled = false;
            chckBoxDelete.Enabled = false;

            //start the watcher
            watcher.EnableRaisingEvents = true;
        }

        

        // Define the event handlers. 
        private void OnWatchedFileChanged(object source, FileSystemEventArgs e)
        {
            if (mApp == null || mApp.ActiveDocument == null) return;

            
            //get a component to use for data dump
            var dump = GetDumpComp();

            //dump changes
            dump.Text = e.Name + "|" + e.FullPath + "|" + e.ChangeType;

            //trigger a script
            var s = GetComponent<M.Script>(callbackScript ?? string.Empty);
            if (s != null)
            {
                s.Run();
            }
        }

        /// <summary>
        /// file watcher notifications manifold component name
        /// </summary>
        private string watcherNotificationsComp = "FileWatcherNotifications";

        /// <summary>
        /// Gets a notifications dump component
        /// </summary>
        /// <returns></returns>
        private M.Comments GetDumpComp()
        {
            M.Document mDoc = mApp.ActiveDocument;

            var dumpCompName = txtDumpName.Text;
            if (string.IsNullOrEmpty(dumpCompName))
            {
                dumpCompName = watcherNotificationsComp;
                txtDumpName.Text = watcherNotificationsComp;
            }

            M.Comments dump = GetComponent<M.Comments>(dumpCompName);
            
            if (dump == null)
            {
                dump = mDoc.NewComments(dumpCompName, true);
            }

            return dump;
        }

        /// <summary>
        /// Gets a manifold component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        private T GetComponent<T>(string name)
        {
            T output = default(T);

            M.Document mDoc = mApp.ActiveDocument;

            foreach (M.Component c in mDoc.ComponentSet)
            {
                if (c.Name == name)
                {
                    if (c.Type == GetComponentType<T>())
                    {
                        output = (T)c;
                    }
                    break;
                }
            }
            return output;
        }

        private M.ComponentType GetComponentType<T>()
        {
            M.ComponentType output = M.ComponentType.ComponentNull;

            if (typeof(M.Comments) == typeof(T))
            {
                output = M.ComponentType.ComponentComments;
            }
            else if (typeof(M.Script) == typeof(T))
            {
                output = M.ComponentType.ComponentScript;
            }

            return output;
        }

        /// <summary>
        /// start watcher callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartWatcher_Click(object sender, EventArgs e)
        {
            StartWatcher();
        }
        
        /// <summary>
        /// stop watcher btn click callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopWatcher_Click(object sender, EventArgs e)
        {
            KillWatcher();
        }
       

        /// <summary>
        /// browse dir btn click callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowseDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new System.Windows.Forms.FolderBrowserDialog())
            {
                dlg.Description = "Pisk a directory to watch for changes";
                dlg.SelectedPath = txtDir.Text;

                var result = dlg.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    txtDir.Text = dlg.SelectedPath;
                }
            }
        }
    }
}
