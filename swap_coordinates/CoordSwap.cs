using Manifold.Interop.Scripts;
using M = Manifold.Interop;

class Script {
	static void Main() {
		M.Application mApp = Context.Application;
		M.Document mDoc = (M.Document)mApp.ActiveDocument;
		M.ComponentSet mCompSet = mDoc.ComponentSet;
		
		mDoc.BatchUpdates = true;
	
		M.Drawing d = (M.Drawing)mCompSet["CoordsToBeSwapped"];
		
		for(int i = 0; i < d.ObjectSet.GeomSet.Count; i++){
			
			M.Geom g = ((M.Geom)d.ObjectSet.GeomSet.get_Item(i));
			M.BranchSet bs = g.get_BranchSet();
			
			for(int n = 0; n < bs.Count; n++){
				M.PointSet ps = bs.get_Item(n).get_PointSet();
				for(int m = 0; m < ps.Count; m++){
					M.Point p = ps.get_Item(m);
					double currentX = p.X;
					double currentY = p.Y;
					p.X = currentY;
					p.Y = currentX;
				}
			}
			

			mApp.StatusText = i.ToString() + " of " + d.ObjectSet.Count.ToString();
		}
		
		mApp.StatusText = "Coord swap finished.";

		mDoc.BatchUpdates = false;
	}	
}
