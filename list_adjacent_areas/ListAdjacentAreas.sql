UPDATE(
	SELECT
		Drw1.ID,
		Drw1.IDs,
		CStr(Drw2.ID) as AdjacentId
	FROM [Drawing] Drw1, [Drawing] Drw2
	WHERE Adjacent(Drw1.ID, Drw2.ID)
	ORDER BY Drw1.ID, AdjacentId
)
SET [IDs] =
	CASE
		WHEN [IDs] = "" THEN [AdjacentId]
		ELSE  [IDs] & ", " & [AdjacentId]
	END
