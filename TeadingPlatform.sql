/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2020/3/19 21:46:37                           */
/*==============================================================*/
CREATE DATABASE TeadingPlatform
GO
USE TeadingPlatform

-- ··15681005658
if exists (select 1
            from  sysobjects
           where  id = object_id('LogisticsInfo')
            and   type = 'U')
   drop table LogisticsInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Orderform')
            and   type = 'U')
   drop table Orderform
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ShopInfo')
            and   type = 'U')
   drop table ShopInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TypeInfo')
            and   type = 'U')
   drop table TypeInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UserInfo')
            and   type = 'U')
   drop table UserInfo
go

/*==============================================================*/
/* Table: LogisticsInfo                                         */
/*==============================================================*/
create table LogisticsInfo (
   LogisticsId          int                  identity,
   LogisticsName    varchar(20)          null,
   constraint PK_LOGISTICSINFO primary key (LogisticsId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('LogisticsInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'LogisticsInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'LogisticsInfo', 
   'user', @CurrentUser, 'table', 'LogisticsInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LogisticsInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogisticsId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LogisticsInfo', 'column', 'LogisticsId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '物流ID',
   'user', @CurrentUser, 'table', 'LogisticsInfo', 'column', 'LogisticsId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LogisticsInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = '物流名称LogisticsName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LogisticsInfo', 'column', 'LogisticsName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '物流名称',
   'user', @CurrentUser, 'table', 'LogisticsInfo', 'column', 'LogisticsName'
go

/*==============================================================*/
/* Table: Orderform                                             */
/*==============================================================*/
create table Orderform (
   OrderformId          int                  identity,
   CommodityId          int                  null,
   UserId               int                  null,
   OrderNumser          varchar(50)          null,
   CommodityCount       int                  null,
   Price                decimal(18,2)        null,
   OrderState           int                  null,
   LogisticsId          int                  null,
   constraint PK_ORDERFORM primary key (OrderformId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Orderform') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Orderform' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Orderform', 
   'user', @CurrentUser, 'table', 'Orderform'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Orderform')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderformId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'OrderformId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单编号',
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'OrderformId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Orderform')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommodityId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'CommodityId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商品编号',
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'CommodityId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Orderform')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'UserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户编号',
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Orderform')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderNumser')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'OrderNumser'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单号',
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'OrderNumser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Orderform')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommodityCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'CommodityCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '购买数量',
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'CommodityCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Orderform')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Price')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'Price'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '消费金额',
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'Price'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Orderform')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderState')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'OrderState'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单状态',
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'OrderState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Orderform')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogisticsId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'LogisticsId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '物流ID',
   'user', @CurrentUser, 'table', 'Orderform', 'column', 'LogisticsId'
go

/*==============================================================*/
/* Table: ShopInfo                                              */
/*==============================================================*/
create table ShopInfo (
   ShopId               int                  identity,
   ShopName             varchar(20)          null,
   CommodityId          int                  null,
   constraint PK_SHOPINFO primary key (ShopId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ShopInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ShopInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'ShopInfo', 
   'user', @CurrentUser, 'table', 'ShopInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ShopInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ShopId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ShopInfo', 'column', 'ShopId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '店铺Id',
   'user', @CurrentUser, 'table', 'ShopInfo', 'column', 'ShopId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ShopInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ShopName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ShopInfo', 'column', 'ShopName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '店铺名称',
   'user', @CurrentUser, 'table', 'ShopInfo', 'column', 'ShopName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ShopInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommodityId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ShopInfo', 'column', 'CommodityId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', @CurrentUser, 'table', 'ShopInfo', 'column', 'CommodityId'
go

/*==============================================================*/
/* Table: TypeInfo                                              */
/*==============================================================*/
create table TypeInfo (
   TypeId               int                  identity,
   TypeName             varchar(20)          null,
   constraint PK_TYPEINFO primary key (TypeId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TypeInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TypeInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'TypeInfo', 
   'user', @CurrentUser, 'table', 'TypeInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TypeInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TypeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TypeInfo', 'column', 'TypeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '类型编号',
   'user', @CurrentUser, 'table', 'TypeInfo', 'column', 'TypeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TypeInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TypeName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TypeInfo', 'column', 'TypeName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '类型名称',
   'user', @CurrentUser, 'table', 'TypeInfo', 'column', 'TypeName'
go

/*==============================================================*/
/* Table: UserInfo                                              */
/*==============================================================*/
create table UserInfo (
   UserId               int                  identity,
   UserName             varchar(20)          null,
   UserPass                varchar(30)          null,
   UserPhoto            varchar(Max)         null,
   UserSex              int                  null,
   ShopId               int                  null,
   UserNumder           varchar(11)          null,
   UserAge              int                  null,
   UserIDNumber         varchar(18)          null,
   constraint PK_USERINFO primary key (UserId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('UserInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'UserInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'UserInfo', 
   'user', @CurrentUser, 'table', 'UserInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户编号',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户昵称',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserPhoto')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserPhoto'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户头像',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserPhoto'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserSex')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserSex'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户性别',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserSex'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ShopId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'ShopId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '店铺Id',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'ShopId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserNumder')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserNumder'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '手机号',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserNumder'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserAge')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserAge'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户年龄',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserAge'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserIDNumber')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserIDNumber'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '身份证',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'UserIDNumber'
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CommodityInfo')
            and   type = 'U')
   drop table CommodityInfo
go

/*==============================================================*/
/* Table: CommodityInfo                                         */
/*==============================================================*/
create table CommodityInfo (
   CommodityId          int                  identity,
   CommodityName        varchar(30)          null,
   TypeId               int                  null,
   ComndityImg          varchar(Max)         null,
   Price                decimal(18,2)        null,
   CommditySum          int                  null,
   CommodityState       int                  null,
   Descride             varchar(Max)         null,
   CommditySize         varchar(30)          null,
   Testuer              varchar(30)          null,
   PutawayTime          datetime             null,
   OutTime              datetime             null,
   constraint PK_COMMODITYINFO primary key (CommodityId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('CommodityInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'CommodityInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '商品信息', 
   'user', @CurrentUser, 'table', 'CommodityInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommodityId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'CommodityId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'CommodityId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommodityName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'CommodityName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商品名称',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'CommodityName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TypeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'TypeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '类型编号',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'TypeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ComndityImg')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'ComndityImg'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商品图片',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'ComndityImg'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Price')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'Price'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商品价格',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'Price'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommditySum')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'CommditySum'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '库存',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'CommditySum'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommodityState')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'CommodityState'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '状态',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'CommodityState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Descride')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'Descride'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '描述',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'Descride'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommditySize')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'CommditySize'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商品尺寸',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'CommditySize'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Testuer')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'Testuer'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '材质',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'Testuer'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PutawayTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'PutawayTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '上架时间',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'PutawayTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CommodityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OutTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'OutTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '下架时间',
   'user', @CurrentUser, 'table', 'CommodityInfo', 'column', 'OutTime'
go

--CommodityInfo商品信息表 LogisticsInfo快递类型表
-- Orderform订单表 ShopInfo购物车信息表
--TypeInfo商品类型表 UserInfo用户表
select * from Orderform o join UserInfo u on u.UserId=o.UserId
 join CommodityInfo c on c.CommodityId=o.CommodityId 
 join LogisticsInfo l on l.LogisticsId=o.LogisticsId
 join ShopInfo s on s.ShopId=u.ShopId
 join TypeInfo t on t.TypeId=c.TypeId
 select UserName from UserInfo

 select * from UserInfo u join ShopInfo s 
 on s.ShopId=u.ShopId