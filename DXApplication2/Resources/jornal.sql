create database dossierMarcher

go

use dossierMarcher

go

drop table etude

select id1 , objet  from [etude]  where validate  = 1 and id1  not in ( select id1  from fk )

create table etude( id1 int primary key identity(1,1) ,  objet text , estimation text , montant money , envoyer_tresoryer date , validate int DEFAULT 0 , délai_dexecution int   , deleted int default 0  , localite int  foreign key references localite(id_l)  , Type_marcher int foreign key references Type_marcher (id_type)  , Nature int foreign key references Nature(id_N)   )

select id1 , objet , estimation , montant , envoyer_tresoryer , validate  , délai_dexecution  , deleted from etude where deleted = 0

select *  from etude


create table publication(id2 int primary key identity(1,1) , Aop varchar(30) , date_jornal date , date_portail date , date_convocation date , date_op date ,  validate int DEFAULT 0 , deleted int default 0 , duree_portail int default 0 ,duree_Jornal int default 0  )

select * from publication


create table fk(id1 int foreign key references etude(id1) on delete cascade on update cascade , id2 int foreign key references publication(id2) on delete cascade on update cascade , primary key(id1,id2)  )

select * from fk

create table SIMPLE_overture(id3 int primary key identity(1,1) , attributaire varchar(50) ,Montant money , num_Marcher varchar(30)  , date_Visa date , date_approbation date  , valide_approbation int default 0 , duree_approbation int default 0, délai_dexecution int , caution_definitif money  , caution_return money , datenotifiy date , date_caution date , valide_caution int default 0 , duree_caution int default 0 ,valide_order_service int default 0 , duree_order_service int default 0  )



create table fk2(id2 int foreign key references publication(id2) on delete cascade on update cascade ,id3 int foreign key references SIMPLE_overture(id1) on delete cascade on update cascade , primary key(id2,id3) )


create table order_service(id_order int primary key identity(1,1) , date_orderService date , délai_Initial int, délai_restant int  , Etat int , id_Overture int foreign key references SIMPLE_overture(id3) on delete cascade on update cascade , validate int DEFAULT 0 )


create table  Etat_order(id_etat int primary key identity(1,1)  , date_deffet date , etat_objet varchar(50)  , order_service int  foreign key references order_service(id_order) on delete cascade on update cascade  )


go

select id2 , Aop , date_jornal , date_portail , date_convocation , validate  , duree_portail , duree_Jornal   from publication where deleted = 0

create table localite (id_l int primary key identity(1,1) , localite varchar(30) )

INSERT INTO localite VALUES ('Marrakech');
INSERT INTO localite VALUES ('Chichaoua');
INSERT INTO localite VALUES ('Al Haouz');
INSERT INTO localite VALUES ('El Kelâa des Sraghna');
INSERT INTO localite VALUES ('Essaouira');
INSERT INTO localite VALUES ('Rehamna');
INSERT INTO localite VALUES ('Safi');
INSERT INTO localite VALUES ('Youssoufia');


create table Type_marcher(id_type int primary key identity(1,1) , type_marcher varchar(50) )
INSERT INTO Type_marcher VALUES ('UNIQUE');




create table Nature(id_N int primary key identity(1,1) , nature varchar(30))

INSERT INTO Nature VALUES ('Travaux');
INSERT INTO Nature VALUES ('Service');
INSERT INTO Nature VALUES ('Formitaire');



-------procedure notify 1    if(validate  = 0) --------------
----- triger after insert update --------------
create trigger s1
 on publication

after insert , update 
as
begin 
declare @id int,
@jornal date ,
@date_op date 

set @id = cast((select top 1 id2 from inserted  )as int)

set @jornal = cast((select top 1 date_jornal from inserted) as date)

set @date_op = cast((select top 1 date_op from inserted) as date)

EXEC p1 @id , @jornal  , @date_op 
 
end







create procedure p1 (@id int ,  @jornal date , @date_op date)
as
begin

declare @validate int,
		@datejornal date,
		@date_portail date,
		@dateop date,
		@duree_Jornal int ,
		@duree_portail int 
		


set @validate = (select validate from publication where id2 = @id)
set @datejornal = (select date_jornal from publication where id2 = @id)
set @date_portail = (select date_portail from publication where id2 = @id)
set @dateop = (select date_op from publication where id2 = @id)
--set @duree_Jornal = (select duree_Jornal from publication where id2 = @id)

if(@validate =0)
begin

 set @duree_Jornal =  cast(((datediff(day,@datejornal,getdate()))*100)/datediff(day,@datejornal,@dateop)as int)

 set @duree_portail = cast(((datediff(day,@date_portail,getdate()))*100)/datediff(day,@date_portail,@dateop)as int)

 update publication set duree_portail = @duree_portail , duree_Jornal = @duree_Jornal where id2 = @id



 end

 end

-------procedure notify 1    if(validate  = 0) --------------
-------procedure notify 2 APPROBATION     if(validate  = 0) --------------
create procedure aprobation (@id int ,  @date_approbation date , @date_overture date )
as

declare	@validate int ,
		@duree_approbation int 
		
		


set @validate = (select valide_approbation from SIMPLE_overture where id3 = @id)

--set @duree_Jornal = (select duree_Jornal from publication where id2 = @id)

if(@validate =0)
begin

 set @duree_approbation =  cast(((datediff(day,@date_overture,getdate()))*100)/75) as int)


 update SIMPLE_overture set duree_approbation = @duree_approbation where id3 = @id


 end

 end






-------procedure notify 2 APPROBATION     if(validate  = 0)  END--------------
-------procedure notify 2 CAUTION     if(validate  = 0) --------------
create procedure CAUTION (@id int ,  @date_notificatin date , @date_caution date )
as

declare	@validate int ,
		@duree_caution int 
		
		


set @validate = (select valide_caution from SIMPLE_overture where id3 = @id)

--set @duree_Jornal = (select duree_Jornal from publication where id2 = @id)

if(@validate =0)
begin

 set @duree_caution =  cast(((datediff(day,@date_notificatin,getdate()))*100)/(datediff(day,@date_notificatin,@date_caution))) as int)


 update SIMPLE_overture set duree_caution = @duree_caution where id3 = @id


 end

 end




-------procedure notify 2 CAUTION     if(validate  = 0)  END --------------

-------procedure notify 3 order service   if(validate  = 0)  END --------------

create procedure order_service (@id int ,  @date_notificatin date , @date_order_service date)

as

declare	@validate int ,
		@duree_order_service int 
		
		


set @validate = (select valide_order_service from SIMPLE_overture where id3 = @id)

--set @duree_Jornal = (select duree_Jornal from publication where id2 = @id)

if ( @validate = 0 )
begin

 set @duree_order_service =  cast(((datediff(day,@date_notificatin,getdate()))*100)/30) as int)


 update SIMPLE_overture set duree_order_service = @duree_order_service where id3 = @id


 end

 end

-------procedure notify 3 order service    if(validate  = 0)  END --------------


 -------------trigger validate 1 ----------------
 create trigger Validate1
 on publication
 after update 
 as
 begin
 declare @validate int ,
 declare @idPUB int 

 set @validate  = (select top 1 validate from inserted)
 set @idPUB  = (select top 1 id2 from inserted)

 if(@validate = 1)
 begin

 update publication set duree_Jornal = 100 , duree_portail  = 100 where id2 = @idPUB

 end
 end


 -------trigger etatorder --------

 create trigger addON_EtatOrder
 on order_service
 after insert , update
 as
 begin
 declare @etat varchar(50)  , 
  @date_orderService DATE ,
  @id_order int


 set @id_order = (select id_order from inserted)

 set @etat = (select Etat from inserted) 

 set @date_orderService = (select date_orderService from inserted )

if not exists ( select @id_order from Etat_order )
 begin
 insert into Etat_order values (@date_orderService , @etat , @id_order )
 end

 else
 begin
 update Etat_order set date_orderService = @date_orderService , Etat  = @etat  where  id_order =  @id_order 
 end

 end


create Procedure suivi_delai( @Etat int , @dateEffet date , @id_order int)

 as 
 begin

 declare @new_delai int
 
 if(@Etat = 0 )
 begin
set @new_delai = cast(datediff(day , @dateEffet , getdate()) as int)

update order_service set délai_restant  = @new_delai where id_order = @id_order



 end
 end

 create trigger stop_order 

 on Etat_order

 after insert ,  update
 as
 begin
declare @date_effect date,
		@new_delai int,
		@id_order int

set  @id_order = (select order_service from inserted)
set @date_effect = (select date_deffet from inserted)
set @new_delai  = cast(DATEDIFF(day , @date_effect  ,getdate()) as int)
update order_service set délai_restant  = @new_delai where id_order = @id_order 

end


 