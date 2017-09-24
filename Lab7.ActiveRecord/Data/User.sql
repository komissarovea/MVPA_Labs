--CREATE LOGIN [User] WITH PASSWORD = '12345678'
--GO
--CREATE USER [User] FOR LOGIN [User]  
--WITH DEFAULT_SCHEMA = dbo
--GO   

--GRANT CONNECT TO [User]

--GO
--ALTER ROLE db_owner ADD MEMBER [User]
GO
ALTER ROLE db_owner ADD MEMBER [guest]

select u.name, g.name
from sysmembers as m
    inner join sys.sysusers u on u.[uid] = m.memberuid
    inner join sys.sysusers g on g.[uid] = m.groupuid

