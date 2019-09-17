Create Table Keywords
(
	Id int not null primary key Auto_increment,
	KeyType varchar(50),
	KeyWord varchar(50),
	Content varchar(200),
	Sort int,
	memo varchar(500)
);
-- seed
insert into Keywords(keyType,KeyWord,Content,Sort,memo) values ('RoleFlag','ADMIN','管理员',1,'');
insert into Keywords(keyType,KeyWord,Content,Sort,memo) values ('RoleFlag','MEMBER','会员',2,'');
insert into Keywords(keyType,KeyWord,Content,Sort,memo) values ('RoleFlag','TEMP','游客',3,'');