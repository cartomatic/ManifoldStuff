using System;
using M = Manifold.Interop;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Some setup stuff first
            string exportFld = "H:\\ExportedComponents\\";

            M.Application mApp = Context.Application;
            M.Document mDoc = (M.Document)mApp.ActiveDocument;
            M.ComponentSet mCompSet = mDoc.ComponentSet;

            //Exporters
            M.ExportShp shpExporter = (M.ExportShp)mApp.NewExport("SHP");
            shpExporter.ConvertPolicy = M.ConvertPolicy.ConvertAll;

            M.ExportXls xlsExporter = (M.ExportXls)mApp.NewExport("XLS");
            xlsExporter.ConvertPolicy = M.ConvertPolicy.ConvertAll;

            //iterate through all components
            for (int i = 0; i < mCompSet.Count; i++ )
            {
                mApp.StatusText = "Reading component " + i.ToString() + " of " + mCompSet.Count;

                switch (mCompSet[i].Type)
                {
                    case M.ComponentType.ComponentDrawing:

                        shpExporter.Export(mCompSet[i], exportFld + mCompSet[i].Name + shpExporter.DefaultExtension, M.ConvertPrompt.PromptNone);

                        break;

                    case M.ComponentType.ComponentTable:

                        xlsExporter.Export(mCompSet[i], exportFld + mCompSet[i].Name + xlsExporter.DefaultExtension, M.ConvertPrompt.PromptNone);
                        break;
                }
            }

            mApp.StatusText = "";
            mApp.MessageBox("Done!", "Info");

        }
    }
}
