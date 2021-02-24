create database dossierMarcher

go

use dossierMarcher

go



create table etude( id1 int primary key identity(1,1) ,  objet text , estimation text , montant money , envoyer_tresoryer date , validate int DEFAULT 0 , deleted int default 0 )

create table publication(id2 int primary key identity(1,1) ,   Aop varchar(30) , date_jornal date , date_portail date , date_convocation date , date_op date ,  validate int DEFAULT 0 , deleted int default 0 , duree_portail int default 0 ,duree_Jornal int default 0  )




create table fk(id1 int foreign key references etude(id1) on delete cascade on update cascade , id2 int foreign key references publication(id2) on delete cascade on update cascade , primary key(id1,id2)  )


go

create procedure p1(@date_jornal date  , @date_portail date )
as
if(date_jornal  )







