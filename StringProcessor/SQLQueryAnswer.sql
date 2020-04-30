
SELECT MAX([Business]) AS Business
	  ,MAX(ISNULL([StreetNo], '')) AS StreetNo
      ,MAX([Street]) AS Street
      ,MAX([PostCode]) AS PostCode
	  ,SUM([Count]) AS FootfallCount
 
FROM [Premises] p WITH(NOLOCK)

LEFT JOIN [Footfall] f WITH(NOLOCK)
ON p.id = f.PremisesId

JOIN [Businesses] b WITH(NOLOCK)
on p.BusinessId = b.id

GROUP BY p.id