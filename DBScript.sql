--Custom Scripts


--DataSeed

DELETE Products
DELETE Categories

SET IDENTITY_INSERT Categories ON
Insert Categories(Id,Name) SELECT 1,'Category1'
Insert Categories(Id,Name) SELECT 2,'Category2'
Insert Categories(Id,Name) SELECT 3,'Category3'
Insert Categories(Id,Name) SELECT 4,'Category4'
SET IDENTITY_INSERT Categories OFF

Insert Products (Name,Price,CategoryId) SELECT 'Product1',145,1
Insert Products (Name,Price,CategoryId) SELECT 'Product3',245,1
Insert Products (Name,Price,CategoryId) SELECT 'Product4',845,2
Insert Products (Name,Price,CategoryId) SELECT 'Product5',745,2
Insert Products (Name,Price,CategoryId) SELECT 'Product6',365,3
Insert Products (Name,Price,CategoryId) SELECT 'Product7',245,3
Insert Products (Name,Price,CategoryId) SELECT 'Product8',745,4
Insert Products (Name,Price,CategoryId) SELECT 'Product9',645,4
Insert Products (Name,Price,CategoryId) SELECT 'Product10',345,1