create database dossierMarcher

go

use dossierMarcher

go

drop table etude

select id1 , objet  from [etude]  where validate  = 1 and id1  not in ( select id1  from fk )

create table etude( id1 int primary key identity(1,1) ,  objet text , estimation text , montant varchar(10) , envoyer_tresoryer date , validate int DEFAULT 0 , délai_dexecution int   , deleted int default 0  , localite int  foreign key references localite(id_l)  , Type_marcher int foreign key references Type_marcher (id_type)  , Nature int foreign key references Nature(id_N)   )

select id1 , objet , estimation , montant , envoyer_tresoryer , validate  , délai_dexecution  , deleted from etude where deleted = 0

select e.objet from etude e inner join fk f on e.id1 = f.id1 inner join publication p on f.id2 = p.id2 where p.id2 = 5


create table publication(id2 int primary key identity(1,1) , Aop varchar(30) , date_jornal date , date_portail date , date_convocation date , date_op date ,  validate int DEFAULT 0 , deleted int default 0 , duree_portail int default 0 ,duree_Jornal int default 0  )

select * from publication


create table fk(id1 int foreign key references etude(id1) on delete cascade on update cascade , id2 int foreign key references publication(id2) on delete cascade on update cascade , primary key(id1,id2)  )


SELECT *   FROM fk2 

select * from SIMPLE_overture

create table SIMPLE_overture(id3 int primary key identity(1,1) , attributaire varchar(50) ,Montant varchar(10) , num_Marcher varchar(30)  , date_Visa date , date_approbation date  , valide_approbation int default 0 , duree_approbation int default 0, délai_dexecution int , caution_definitif varchar(10)  , caution_return varchar(10) , datenotifiy date , date_caution date , valide_caution int default 0 , duree_caution int default 0 ,valide_order_service int default 0 , duree_order_service int default 0  )

select * from SIMPLE_overture

select id3 , attributaire , Montant , num_Marcher , date_Visa  , date_approbation  , valide_approbation  , duree_approbation , délai_dexecution  , caution_definitif , caution_return , datenotifiy , date_caution , valide_caution , duree_caution  , valide_order_service  , duree_order_service from SIMPLE_overture

select id1 , objet , estimation , montant , envoyer_tresoryer , validate  , délai_dexecution   from etude where deleted = 0   order by id1 desc ;
create table fk2(id2 int foreign key references publication(id2) on delete cascade on update cascade ,id3 int foreign key references SIMPLE_overture(id3) on delete cascade on update cascade , primary key(id2,id3) )


create table order_service(id_order int primary key identity(1,1) , date_orderService date , délai_Initial int, délai_restant int  , Etat int , id_Overture int foreign key references SIMPLE_overture(id3) on delete cascade on update cascade , validate int DEFAULT 0 )


create table  Etat_order(id_etat int primary key identity(1,1)  , date_deffet date , etat_objet varchar(50)  , order_service int  foreign key references order_service(id_order) on delete cascade on update cascade  )

select * from etude

select * from fk

select * from publication

go
select id2 , Aop   from [publication]  where validate  = 1 and id2  not in ( select id2  from fk2 )

select e.[délai_dexecution] from etude e inner join  fk f on e.id1 = f.id1 inner join  publication p on p.id2 = f.id2 where p.Aop = 'test3'

select id2 , Aop   from [publication]  where validate  = 1 and id2  not in ( select id2  from fk2 )

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
alter trigger s1
 on publication

after insert , update 
as
begin 
declare @id int,

@jornal date ,
@date_op date ,
@validate int


set @id = cast((select top 1 id2 from inserted  )as int)

set @jornal = cast((select top 1 date_jornal from inserted) as date)

set @date_op = cast((select top 1 date_op from inserted) as date)

set @validate = (select validate from publication where id2 = @id)

if(@validate =0)

begin

EXEC p1 @id , @jornal  , @date_op 
 
 end
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
 alter trigger Validate1
 on publication
 after update 
 as
 begin
 declare @validate int ,
  @idPUB int 

 set @validate  = (select top 1 validate from inserted)
 set @idPUB  = (select top 1 id2 from inserted)

 if(@validate = 1)
 begin

 update publication set duree_Jornal = 100 , duree_portail  = 100 where id2 = @idPUB

 end

  if(@validate = -1)
 begin

 update publication set duree_Jornal = 0 , duree_portail  = 0 where id2 = @idPUB

 end
 end

 select  o.[id_order] , f.[date_deffet] , f.[etat_objet]  , o.[délai_restant] from   order_service o   inner join Etat_order f on   f.order_service = o.id_order where o.[id_order] = 6 

 select * from etude

 select  v.[num_Marcher] , e.id_etat , o.date_orderService , o.Etat , o.délai_Initial , o.délai_restant , o.id_order  from SIMPLE_overture v  inner join order_service o  on o.id_Overture = v.id3 inner join Etat_order  e on e.order_service = o.id_order  where o.id_Overture = 10

 ------------------trigger validate simple overt-------------------
  ALTER trigger Validate_overt
  on SIMPLE_overture
  after update 
 as
 begin
  declare @validateapprobation int ,
   @validatecaution int ,
   @validatesimpleovert int ,
   @id3 int 
   set @validateapprobation  = (select top 1 valide_approbation from inserted)
   set @validatecaution  = (select top 1 valide_caution from inserted)
   set @validatesimpleovert  = (select top 1 valide_order_service from inserted)
   set @id3  = (select top 1 id3 from inserted)
   if(@validateapprobation = 1)
 begin

 update SIMPLE_overture set duree_approbation = 100  where id3 = @id3

 end
  if(@validatecaution = 1)

 begin

 update SIMPLE_overture set duree_caution = 100  where id3 = @id3

 end

  if(@validatesimpleovert = 1)
 begin

 update SIMPLE_overture set duree_order_service = 100  where id3 = @id3

 INSERT INTO order_service 

 end
   

   end
 


 -------trigger etatorder --------

 create trigger addON_EtatOrder 
 on order_service 
 after insert , update 
 as 
 begin 
 declare @etat varchar(50), 
  @date_orderService DATE ,
  @id_order int


 set @id_order = (select id_order from inserted)

 set @etat = (select Etat from inserted ) 

 set @date_orderService = (select date_orderService from inserted )

if not exists ( select @id_order from Etat_order )
 begin
 insert into Etat_order values (@date_orderService , @etat , @id_order )
 end

 else
 begin
 update Etat_order set date_deffet = @date_orderService , etat_objet  = @etat  where  order_service =  @id_order 
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


 