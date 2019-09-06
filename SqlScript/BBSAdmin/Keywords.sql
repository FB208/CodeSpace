

Create Table Keywords
(
	Id int identity(1,1) primary key,
	KeyType varchar(50),
	KeyWord varchar(50),
	Content varchar(200),
	Sort int,
	memo varchar(max)
)

--seed
insert into keywords(keyType,KeyWord,Content,Sort,memo)
values ('RoleFlag','ADMIN','����Ա',1,'')
insert into keywords(keyType,KeyWord,Content,Sort,memo)
values ('RoleFlag','MEMBER','��Ա',2,'')
insert into keywords(keyType,KeyWord,Content,Sort,memo)
values ('RoleFlag','TEMP','�ο�',2,'')