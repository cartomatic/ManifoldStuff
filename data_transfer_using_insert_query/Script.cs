using Manifold.Interop.Scripts;

using m = Manifold.Interop;

class Script {
	static void Main() {

		long start = System.DateTime.Now.Ticks;

		m.Application mApp = Context.Application;
		m.Document mDoc = (m.Document)mApp.ActiveDocument;

		m.ComponentSet mCompSet = mDoc.ComponentSet;

		m.ColumnSet mColSet = mApp.NewColumnSet();
		mColSet.Add(mColSet.NewColumn());

		m.Table mT = mDoc.NewTable("TempTbl", mColSet, false);
		
		mT.RecordSet.AddNew();

		m.Query mQ = (m.Query)mDoc.NewQuery("TempQuery", false);

		for(int l = 0; l < 1; l++){

			//mApp.History.Log(l.ToString() + System.Environment.NewLine, false);			

			string q = "INSERT INTO [DestinationDrawing] ([Geom (I)], [intCol], [floatCol], [strCol], [dateCol]) ";
			for(int i = 0; i < 100; i++){
				if(i > 0){
					q += " UNION ALL ";
				}
				q += " SELECT CGEOMWKB(\"POINT(" + i.ToString() + " " + i.ToString() +  ")\"), 1.54 , 2.54, \"xxx\", \"2011-07-24 19:54:16\" FROM [TempTbl] ";
			}
	
			mQ.Text = q;
			
			mQ.RunEx(true);
		}
		
		mCompSet.Remove(mT);
		mCompSet.Remove(mQ);

		long end = System.DateTime.Now.Ticks;

		System.TimeSpan ts = new System.TimeSpan(end - start);
        mApp.History.Log("Total: " + ts.TotalSeconds.ToString(), false);

	}
}
