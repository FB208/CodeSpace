use BBSAdmin

Create Table UserTable
(
	UUID varchar(50) primary key,
	UserName varchar(50),
	NickName nvarchar(50),
	PWD varchar(50),
	Introduction nvarchar(500),--���˽���
	Email varchar(100),
	RoleFlag varchar(50),
	HomePage varchar(500),--��ҳ
	Tel varchar(50)
)


--seed
insert into UserTable values(NEWID(),'admin','FB208','1','��Ӹ���ǩ��','472189065@qq.com','ADMIN','https://github.com/FB208/CodeSpace','13820044712')

