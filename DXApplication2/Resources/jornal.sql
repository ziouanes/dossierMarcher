create database dossierMarcher

go


go

drop table etude

select Aop , num_Marcher  , 'REGION MARRAKECH SAFI'  , 'MARCHE'  , 'MARCHE UNIQUE'  , localité , date_op , estimation , attributaire , montant , Etat  from localite l inner join etude , publication , SIMPLE_overture , localite

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


CREATE trigger s1
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

 exec aprobation 10 

-------procedure notify 1    if(validate  = 0) --------------
-------procedure notify 2 APPROBATION     if(validate  = 0) --------------
alter procedure aprobation (@id int)
as
BEGIN

declare @date_approbation date,
@date_overture date , 

	@validate int ,
		@DUREE_app int 
	
set	@date_overture = (select p.date_op from publication p inner join fk2 k on p.id2 = k.id2 inner join SIMPLE_overture s on s.id3 = k.id3 where s.id3 = @id )
		
set @date_approbation = (select date_approbation from SIMPLE_overture where id3  = @id)

set @validate = (select valide_approbation from SIMPLE_overture where id3 = @id)

--set @duree_Jornal = (select duree_Jornal from publication where id2 = @id)

if(@validate =0)
begin

SET @DUREE_app = cast((datediff(day,@date_overture,GETDATE()))*100/datediff(day,@date_overture ,@date_approbation) as int)



 update SIMPLE_overture set duree_approbation = @DUREE_app where id3 = @id


 end

 end






-------procedure notify 2 APPROBATION     if(validate  = 0)  END--------------
-------procedure notify 2 CAUTION     if(validate  = 0) --------------
create procedure CAUTION (@id int )
as
BEGIN
declare	@validate int ,
		@duree_caution int ,
		@date_notificatin date ,
		@date_caution date , 
		@boolnoty int,
		@boolcaution int
		
		if exists ( select  datenotifiy from SIMPLE_overture where id3 = @id  )
		begin

		set @date_notificatin = ( select   datenotifiy from SIMPLE_overture where id3 = @id ) ;
		set @boolnoty = 1

		end
		else
		set @boolnoty = 0

		------------
		if exists ( select   date_caution from SIMPLE_overture where id3 = @id   )
		begin

		set @date_notificatin = ( select   date_caution from SIMPLE_overture where id3 = @id ) ;
		set @boolnoty = 1

		end
		else
		set @boolnoty = 0


set @validate = (select valide_caution from SIMPLE_overture where id3 = @id)

--set @duree_Jornal = (select duree_Jornal from publication where id2 = @id)

if(@validate =0 and @boolnoty = 1 and @boolcaution = 1)
begin

 set @duree_caution =  cast(((datediff(day,@date_notificatin,getdate()))*100)/datediff(day,@date_notificatin,@date_caution) as int)


 update SIMPLE_overture set duree_caution = @duree_caution where id3 = @id


 end

 end




-------procedure notify 2 CAUTION     if(validate  = 0)  END --------------

-------procedure notify 3 order service   if(validate  = 0)  END --------------

create procedure _order_service (@id int )

as
begin

declare	@validate int ,
		@duree_order_service int ,
		@date_notification date ,
				@boolnoty int
if exists ( select  datenotifiy from SIMPLE_overture where id3 = @id  )
		begin

		set @date_notification = ( select   datenotifiy from SIMPLE_overture where id3 = @id ) ;
		set @boolnoty = 1

		end
		else
		set @boolnoty = 0

		
		


set @validate = (select valide_order_service from SIMPLE_overture where id3 = @id)

--set @duree_Jornal = (select duree_Jornal from publication where id2 = @id)

if ( @validate = 0 and @boolnoty = 1)
begin
			
 set @duree_order_service =  cast(((datediff(day,@date_notification,getdate()))*100)/(30) as int)


 update SIMPLE_overture set duree_order_service = @duree_order_service where id3 = @id
	

 end

 end



-------procedure notify 3 order service    if(validate  = 0)  END --------------
	
--//المعلومة
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

 update publication set duree_Jornal = -1 , duree_portail  = -1 where id2 = @idPUB

 end
 end

 
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
 


 select  v.[num_Marcher] , e.id_etat , o.date_orderService , o.Etat , o.délai_Initial , o.délai_restant, o.id_order   from SIMPLE_overture v  inner join order_service o  on o.id_Overture = v.id3 inner join Etat_order  e on e.order_service = o.id_order  where o.id_Overture = 10 

 -------trigger etatorder --------

 alter trigger addON_EtatOrder 
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

if not exists ( select id_order = @id_order  from Etat_order )
 begin
 insert into Etat_order values (@date_orderService , @etat , @id_order )
 end

 

 end

 -----trriger update etat order service ---------

 alter trigger update_EtatOrder 
 on Etat_order 
 after insert 
 as 
 begin 
 declare @etat varchar(50), 
  
  @id_order int , 

  @date_orderService date


 set @id_order = (select top 1 order_service from inserted order by date_deffet desc )

 set @etat = (select top 1 etat_objet  from inserted order by date_deffet desc  ) 

 set @date_orderService = (select top 1 date_deffet from inserted order by date_deffet desc )





--if  exists ( select top 1 order_service  , date_deffet  from Etat_order where order_service = @id_order order by date_deffet desc )

-- begin

 update order_service set Etat = @etat where id_order =  @id_order 

 --end

 

 end

 -----procedure calcule delai restant--------
 DECLARE @etat int;
 exec suivi_delai  1,  '2021-03-06' , 14 ,  @etat OUTPUT
SELECT @etat AS 'etat';
alter Procedure suivi_delai( @Etat int , @dateEffet date , @id_order int ,  @etatR int OUTPUT)

 as 
 begin

 declare @new_delai int
 
 
 if(@Etat = 1 or @Etat = -1  )
 begin


set @new_delai = cast(datediff(day , @dateEffet , getdate()) as int)

if(@new_delai>=0)
begin

update order_service set délai_restant  = @new_delai where id_order = @id_order
  select @etatR = @new_delai

end
else
begin
update order_service
set délai_restant  = 0 where id_order = @id_order
  select @etatR = 0

end


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




select  e.validate as 'etude_V'  ,   p.validate as 'public_V'   ,  o.etat ,  s.valide_approbation , s.valide_caution , s.valide_order_service  ,    s.num_Marcher ,   e.id1 , e.objet from etude e inner join fk k on e.id1 = k.id1 inner join publication p on p.id2 = k.id2 inner join fk2 pk on pk.id2 =  p.id2 inner join SIMPLE_overture s on s.id3 = pk.id3 inner join order_service o on o.id_order = s.id3  where s.num_Marcher = '12AA'


select p.id2 , p.validate  from publication p inner join fk f on f.id2 = p.id2 inner join etude e on e.id1 = f.id1  where  e.id1 = 5   ;


select  [id1] , [validate] from etude where id1 = 

select p.id2 , p.Aop  from publication p inner join fk f on f.id2 = p.id2 inner join etude e on e.id1 = f.id1  where  e.id1 = 5   ;

select s.id3 , s.num_Marcher  from publication p inner join fk f on f.id2 = p.id2 inner join etude e on e.id1 = f.id1 inner join fk2 k2 on k2.id2 = p.id2 inner join SIMPLE_overture s on s.id3 = k2.id3  where  e.id1 = 5    ;


select  [id1] , [validate] from etude where id1 = '3'


select e.validate as 'etude_V' , p.validate as 'public_V'   ,  o.etat ,  s.valide_approbation , s.valide_caution , s.valide_order_service  ,    s.num_Marcher ,   e.id1 , e.objet from etude e FULL OUTER JOIN fk k on e.id1 = k.id1 FULL OUTER JOIN publication p on p.id2 = k.id2 FULL OUTER JOIN fk2 pk on pk.id2 =  p.id2 FULL OUTER JOIN SIMPLE_overture s on s.id3 = pk.id3 FULL OUTER JOIN order_service o on o.id_order = s.id3  where e.id1 = 2



select e.validate as 'etude_V' , p.validate as 'public_V'   ,  o.etat ,  s.valide_approbation , s.valide_caution , s.valide_order_service  ,    s.num_Marcher ,   e.id1 , e.objet from etude e inner join fk k on e.id1 = k.id1 inner join publication p on p.id2 = k.id2 inner join fk2 pk on pk.id2 =  p.id2 inner join SIMPLE_overture s on s.id3 = pk.id3 FULL OUTER JOIN order_service o on o.id_order = s.id3


 select e.validate as 'etude_V' , p.validate as 'public_V'   ,  o.etat ,  s.valide_approbation , s.valide_caution , s.valide_order_service  ,    s.num_Marcher ,   e.id1 , e.objet , o.id_order from etude e inner join fk k on e.id1 = k.id1 inner join publication p on p.id2 = k.id2 inner join fk2 pk on pk.id2 =  p.id2 inner join SIMPLE_overture s on s.id3 = pk.id3 FULL OUTER JOIN order_service o on o.id_order = s.id3  where e.id1 =1 

select  o.[délai_Initial] , t.[etat_objet] , t.[date_deffet] from order_service o inner join  [dbo].[Etat_order] t on o.id_order = t.order_service where o.id_order = 6

select top 1  p.Aop , o.délai_restant , e.estimation ,  s.attributaire , o.délai_Initial  , e.montant , p.date_op , p.date_portail  ,  o.etat  ,    s.num_Marcher ,   e.id1 , e.objet , et.date_deffet from etude e FULL OUTER JOIN fk k on e.id1 = k.id1 FULL OUTER JOIN publication p on p.id2 = k.id2 FULL OUTER JOIN fk2 pk on pk.id2 =  p.id2 FULL OUTER JOIN SIMPLE_overture s on s.id3 = pk.id3 FULL OUTER JOIN order_service o on o.id_order = s.id3 FULL OUTER JOIN Etat_order et on o.id_order = et.order_service   where e.id1 = 1 and et.etat_objet = 1  order by et.date_deffet desc


select  o.[délai_Initial] , t.[etat_objet] , t.[date_deffet] from order_service o inner join  [dbo].[Etat_order] t on o.id_order = t.order_service where o.id_order = 6



select p.Aop as 'N°AOP' , e.fdr , e.délai_dexecution , s.num_Marcher as 'N°MARCHE'  , l.localite as 'Localité des Tran' ,e.objet, p.date_op as 'Date ouverture des Plis' , e.estimation as 'Estimation' , s.attributaire as 'ATTRIBUTAIRE' , e.montant as 'MONTANT' , CAST(o.Etat as varchar(20)) as 'Etat'    from localite l FULL OUTER JOIN  etude e on l.id_l = e.localite inner join fk k on e.id1 = k.id1 FULL OUTER JOIN publication p on p.id2 = k.id2 FULL OUTER JOIN fk2 pk on pk.id2 =  p.id2 FULL OUTER JOIN SIMPLE_overture s on s.id3 = pk.id3 FULL OUTER JOIN order_service o on o.id_order = s.id3  where 1=1 and YEAR( p.date_op)  = '2021' order by p.date_op desc

--/////appointement
drop trigger appointement
create trigger appointement 
 on publication 
 after insert 
 as 
 begin 
 declare @Aoo varchar(50), 
 @datejornal date,
 @dateconvocation date , 
 @dateportail date ,
 @dateop date

  


 set @Aoo = (select top 1 Aop from inserted c )

 set @datejornal = (select top 1 date_jornal  from inserted ) 

 set @dateconvocation = (select top 1 date_convocation  from inserted ) 


 set @dateop = (select top 1 date_op from inserted  )

 set @dateportail = (select top 1 date_portail  from inserted ) 

 insert into Appointments(StartDate ,EndDate ,[Subject] ,[Description],AllDay ) values (@datejornal , @datejornal ,'Date Jornal  Aop° '+@Aoo , '-','True' )
 insert into Appointments(StartDate ,EndDate ,[Subject] ,[Description] ,AllDay  ) values (@dateop , @dateop ,'Date op Aop° '+@Aoo , '-' ,'True' )
 insert into Appointments(StartDate ,EndDate ,[Subject] ,[Description] ,AllDay  ) values (@dateportail , @dateportail ,'date Portail Aop° '+@Aoo , '-','True' )
 insert into Appointments(StartDate ,EndDate ,[Subject] ,[Description] ,AllDay  ) values (@dateconvocation , @dateconvocation ,'date Convocation Aop° '+@Aoo , '-','True' )








 end

 --appointement date portail
 --/////appointement
 drop trigger appointement_portail
alter trigger appointement_portail
 on publication 
  after update 
 as 
 begin 
 declare @Aoo varchar(50), 
 @dateapprobation date,
 @validate int ,
 @dateop date,
 @idpub int ,
 @deleted int

  set @deleted =(select top 1 deleted from inserted)
  set @Aoo = (select top 1 Aop from inserted)
 set @idpub = (select top 1 id2 from inserted )
 set @dateop = (select top 1 date_op from inserted  )
 set @validate = (select top 1 validate from inserted where id2 = @idpub)
 set @dateapprobation = (DATEADD(DAY, 75, @dateop))
 

 if(@validate = 1 and @deleted = 0)
 begin


  insert into Appointments(StartDate ,EndDate ,[Subject] ,[Description],AllDay ) values (@dateapprobation , @dateapprobation ,'Date Approbation  Aop° '+@Aoo , '-','True' )
  update publication set  deleted = -1 where id2 = @idpub

 end

 end


 
-------procedure notify 3 order service    if(validate  = 0)  END --------------
	
--//المعلومة
 -------------trigger validate 1 ----------------
 alter trigger Validate1
 on publication
 after update 
 as
 begin
 declare @validate int ,
  @idPUB int ,
  @Aoo varchar(50), 
 @dateapprobation date,
 @dateop date,
 @deleted int

 set @deleted =(select top 1 deleted from inserted)
set @Aoo = (select top 1 Aop from inserted)
 set @dateop = (select top 1 date_op from inserted  )
 set @dateapprobation = (DATEADD(DAY, 75, @dateop))

 set @validate  = (select top 1 validate from inserted)
 set @idPUB  = (select top 1 id2 from inserted)

 if(@validate = 1)
 begin
insert into Appointments(StartDate ,EndDate ,[Subject] ,[Description],AllDay ) values (@dateapprobation , @dateapprobation ,'Date Approbation  Aop° '+@Aoo , '-','True' )
 update publication set duree_Jornal = 100 , duree_portail  = 100 where id2 = @idPUB

 end

  if(@validate = -1)
 begin

 update publication set duree_Jornal = -1 , duree_portail  = -1 where id2 = @idPUB

 end
 end


 select p.id2 , p.Aop  from publication p inner join fk f on f.id2 = p.id2 inner join etude e on e.id1 = f.id1 where e.id1 = 1;


select s.id3 , s.num_Marcher  from publication p inner join fk f on f.id2 = p.id2 inner join etude e on e.id1 = f.id1 inner join fk2 k2 on k2.id2 = p.id2 inner join SIMPLE_overture s on s.id3 = k2.id3  where   p.id2 = 13
-----EDIT APPOINTEMENT

USE [dossierMarcher]
GO
/****** Object:  Trigger [dbo].[appointement]    Script Date: 6/18/2021 11:01:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[appointement] 
 on [dbo].[publication] 
 after insert , update
 as 
 begin 
 declare @Aoo varchar(50), 
 @datejornal date,
 @dateconvocation date , 
 @dateportail date ,
 @dateop date ,
 @description varchar(50)

  


 set @Aoo = (select top 1 Aop from inserted c )

 set @datejornal = (select top 1 date_jornal  from inserted ) 

 set @dateconvocation = (select top 1 date_convocation  from inserted ) 


 set @dateop = (select top 1 date_op from inserted  )

 set @dateportail = (select top 1 date_portail  from inserted ) 

 

 if not exists(select * from Appointments where [Description] = @Aoo )

 begin

 insert into Appointments(StartDate ,EndDate ,[Subject] ,[Description],AllDay ) values (@datejornal , @datejornal ,'Date Jornal  Aop° '+@Aoo ,@Aoo,'True' )
 insert into Appointments(StartDate ,EndDate ,[Subject] ,[Description] ,AllDay  ) values (@dateop , @dateop ,'Date op Aop° '+@Aoo ,@Aoo ,'True' )
 insert into Appointments(StartDate ,EndDate ,[Subject] ,[Description] ,AllDay  ) values (@dateportail , @dateportail ,'date Portail Aop° '+@Aoo ,@Aoo,'True' )
 insert into Appointments(StartDate ,EndDate ,[Subject] ,[Description] ,AllDay  ) values (@dateconvocation , @dateconvocation ,'date Convocation Aop° '+@Aoo , @Aoo,'True' )

 end

 else
 update Appointments set StartDate = @datejornal , EndDate = @datejornal where  [Description] = @Aoo and [Subject] like '%Date Jornal%'
 update Appointments set StartDate = @dateop , EndDate = @dateop where  [Description] = @Aoo and [Subject] like '%Date op%'
 update Appointments set StartDate = @dateportail , EndDate = @dateportail where  [Description] = @Aoo and [Subject] like '%Date Portail%'
 update Appointments set StartDate = @dateconvocation , EndDate = @dateconvocation where  [Description] = @Aoo and [Subject] like '%Date Convocation%'


 end

 ------END EDIT
