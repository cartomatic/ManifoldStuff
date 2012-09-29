SELECT
	[ID],
	AllBranches([GeomData]) AS [GeomData]
FROM (
	SELECT
		Max([ID]) AS [ID],
		ConvertToArea(
			AllCoords(AssignCoordSys(
				NewPoint(Y, X), -- invert coords here
				CoordSys("Latitude / Longitude") --can be any other coordsys of course
			)
		)) as [GeomData]	
	FROM (
		SELECT [ID], [B], MaxX([C]) as X, MaxY([C]) as Y
		FROM (
			SELECT
				[ID],
				[B]
			FROM
				[CoordsToBeSwapped_source]
			SPLIT BY Branches([ID]) AS [B] --used later to group the points
			)
		SPLIT BY Coords([B]) AS [C]
		)
	GROUP BY [B]
	)
GROUP BY [ID]