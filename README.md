# AdvancedQueryChallenge-LINQ-SQL-.NET-
I was dabbling in LINQ to SQL and completed this advanced query challenge
Challenge Guidelines:

 Consider the following example data:

var soldItems = [

  {id: 1, name: "Rock Salt", serialNumber: "RS1", cost: 10, salePrice: 50, salesPerson: "Andy Ghadban"},

  {id: 2, name: "Planter's Nuts", serialNumber: "XO28-V", cost: 4, salePrice: 23, salesPerson: "Reginald VelJohnson"},

  {id: 3, name: "Bulk Pack SuperWash Fire Hoses", serialNumber: "BPSW-FH3", cost: 122, salePrice: 122, salesPerson: "Harry Lewis"},

  {id: 4, name: "BlackBOX carnival sticks", serialNumber: "BBOX4", cost: 215, salePrice: 460, salesPerson: "Jean-Luc Picard"},

  {id: 5, name: "ARMY surplus Canned Beef", serialNumber: "5-ARMYCB", cost: 34, salePrice: 513, salesPerson: "Jean-Luc Picard"},

  {id: 6, name: "Compressed Air", serialNumber: "CA6", cost: 80, salePrice: 900, salesPerson: "Frank Castle"},

  {id: 7, name: "Rock Salt", serialNumber: "RS1", cost: 10, salePrice: 2, salesPerson: "Reginald VelJohnson"},

  {id: 8, name: "Werther's Original", serialNumber: "WO-8", cost: 12, salePrice: 75, salesPerson: "Andy Ghadban"},

  {id: 9, name: "tonka truck passenger door", serialNumber: "TT-PD-9", cost: 336, salePrice: 275, salesPerson: "Jean-Luc Picard"},

  {id: 10, name: "ARMY surplus Canned Beef", serialNumber: "5-ARMYCB", cost: 12, salePrice: 6000, salesPerson: "Frank Castle"},

  {id: 11, name: "SwashBuckler's Buckled Swashes", serialNumber: "SBBS11", cost: 122, salePrice: 160, salesPerson: "Harry Lewis"}

];

A particular search query requires data pull results to be filtered in such a way that only profitable items that were sold exactly once whose serial number consists of the capital letters of their name joined with their ID (punctuation and casing ignored) in descending order of the overall most profitable salespeople.

How would this query be performed and what is the time/space efficiency of your solution?
