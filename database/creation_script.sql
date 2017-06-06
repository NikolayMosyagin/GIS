-- Создание таблицы для хранения владельца таблиц

--Создаем таблицу owner
create table owner(
owner_id int not null primary key,
owner_name varchar(100)
);

-- Создаем последовательность для генерации первичных ключей таблицы owner
create sequence owner_seq start with 1 increment by 1 cache 2;

-- Создаем триггер для таблицы owner, которые при добавлении кортежа если не установлен первичный ключ генерирует его
create trigger owner_trg
before insert on owner
for each row
begin
    if :new.owner_id is null then
        select owner_seq.nextval into :new.owner_id from dual;
    end if;
end;

commit;

-- Создаем последовательность для генерации первичных ключей таблицы object_type;
create sequence object_type_seq
increment by 1
start with 1
cache 2;

-- создаем таблицу object_type, в которой хранятся метаданные по объектам
create table object_type(
object_type_id int not null primary key,
owner_id int not null,
object_name varchar2(100) not null,
is_Geo int not null,
theme_name varchar2(100) not null,
geo_object_name varchar2(100),
foreign key(owner_id) references owner(owner_id));

-- создаем триггер для таблицы object_type. Он генерирует первичный ключ таблицы, если при добавление кортежа он отсутствует.
create trigger object_type_trg
before insert on object_type
for each row
begin 
    if :new.object_type_id is null then
        select object_type_seq.nextval into :new.object_type_id from dual;
    end if;
end;

commit;

-- Создаем последовательность для генерации первичных ключей таблицы session;
create sequence cache_session_seq start with 1 increment by 1 cache 2;

-- Создаем таблицу session для хранение информации по сессии анализа.
create table cache_session(
session_id int not null primary key,
creation_date date not null,
session_description varchar2(1000));

-- создаем триггер для таблицы session. Он генерирует первичный ключ таблицы, если при добавление кортежа он отсутствует.
create trigger session_trg
before insert on cache_session
for each row
begin
    if :new.session_id is null then
        select cache_session_seq.nextval into :new.session_id from dual;
    end if;
end;

commit;

-- Создаем таблицу cache_object, для хранения объектов доступных для анализа.
create table cache_object(
session_id int not null,
object_type_id int not null,
object_value int not null,
foreign key(session_id) references cache_session(session_id) on delete cascade,
foreign key(object_type_id) references object_type(object_type_id));



-- Создаем последовательность для генерации первичных ключей таблицы attribute_type
create sequence attribute_type_seq
increment by 1
start with 1
cache 2;

-- создаем таблицу attribute_type, в которой хранятся метаданные по атрибутам таблиц доступных для анализа.
create table attribute_type(
attribute_type_id int not null primary key,
attribute_name varchar2(100) not null,
object_type_id int not null,
data_type varchar2(50),
foreign key(object_type_id) references object_type(object_type_id));

-- cоздаем триггер для таблицы attribute_type. генерирует первичный ключ таблицы, если при добавление кортежа он отсутствует.
create trigger attribute_type_trg
before insert on attribute_type
for each row
begin 
    if :new.attribute_type_id is null then
        select attribute_type_seq.nextval into :new.attribute_type_id from dual;
    end if;
end;

commit;


-- Создаем таблицу cache_attribute, для хранения значений атрибутов.
create table cache_attribute(
session_id int not null,
attribute_id int not null,
object_value int not null,
str_val varchar2(2000),
number_val number,
date_val date,
geometry_val SDO_GEOMETRY,
foreign key(session_id) references cache_session(session_id) on delete cascade,
foreign key(attribute_id) references attribute_type(attribute_type_id));

-- insert into user_sdo_geom_metadata(table_name, column_name, diminfo)
-- values('CACHE_ATTRIBUTE', 'GEOMETRY_VAL', (select us.diminfo from user_sdo_geom_metadata us where table_name = 'GEO_BUILDINGS_AREA')); 
create index cache_attribute_geometry_idx on cache_attribute(geometry_val)
indextype is MDSYS.SPATIAL_INDEX;

commit;

-- Создаем последовательность для генерации первичных ключей таблицы operation
create sequence operation_seq
increment by 1
start with 1
cache 2;

-- Создаем таблицу operation, для хранения возможных операций, из которых будет строится правило.
create table operation(
operation_id int not null primary key,
first_object_type_id int not null,
second_object_type_id int,
operation_name varchar2(100) not null,
operation_procedure varchar2(100) not null,
Operation_description varchar2(2000),
foreign key(first_object_type_id) references object_type(object_type_id),
foreign key(second_object_type_id) references object_type(object_type_id));

-- cоздаем триггер для таблицы info_cache. генерирует первичный ключ таблицы, если при добавление кортежа он отсутствует.
create trigger operation_trg
before insert on operation
for each row
begin 
    if :new.operation_id is null then
        select operation_seq.nextval into :new.operation_id from dual;
    end if;
end;

-- Создаем последовательность для генерации первичных ключей таблицы rule
create sequence rule_seq
increment by 1
start with 1
cache 2;

-- Создаем таблицу Rule, для хранения возможных правил.
create table rule(
rule_id int not null primary key,
rule_name varchar2(100) not null,
rule_description varchar2(2000) not null);

-- cоздаем триггер для таблицы Rule. генерирует первичный ключ таблицы, если при добавление кортежа он отсутствует.
create trigger rule_trg
before insert on rule
for each row
begin 
    if :new.rule_id is null then
        select rule_seq.nextval into :new.rule_id from dual;
    end if;
end;

-- Создаем таблицу связи между operation и rule
create table rule_operation(
rule_id int not null,
operation_id int not null,
orderBy int not null,
foreign key(rule_id) references rule(rule_id),
foreign key(operation_id) references operation(operation_id) on delete cascade);
commit;

-- Создаем последовательность для генерации первичных ключей таблицы cache_log
create sequence cache_log_seq
increment by 1
start with 1
cache 2;

create table cache_log(
log_id int not null primary key,
session_id int not null,
operation_id int not null,
first_object_id int not null,
second_object_id int,
result int not null,
foreign key(session_id) references cache_session(session_id) on delete cascade,
foreign key(operation_id) references operation(operation_id) on delete cascade);

-- cоздаем триггер для таблицы cache_log. генерирует первичный ключ таблицы, если при добавление кортежа он отсутствует.
create trigger cache_log_trg
before insert on cache_log
for each row
begin 
    if :new.log_id is null then
        select cache_log_seq.nextval into :new.log_id from dual;
    end if;
end;


-- Создаем роль пользователя.

create role town_planning_users;
grant select on ATTRIBUTE_TYPE to town_planning_users;
grant select on OBJECT_TYPE to town_planning_users;
grant select on OPERATION to town_planning_users;
grant select on RULE to town_planning_users;
grant select on RULE_OPERATION to town_planning_users;
grant select on CACHE_ATTRIBUTE to town_planning_users;
grant select on CACHE_LOG to town_planning_users;
grant select on CACHE_OBJECT to town_planning_users;
grant select on CACHE_SESSION to town_planning_users;
grant select on OWNER to town_planning_users;
grant insert on CACHE_ATTRIBUTE to town_planning_users;
grant insert on CACHE_LOG to town_planning_users;
grant insert on CACHE_OBJECT to town_planning_users;
grant insert on CACHE_SESSION to town_planning_users;

create role town_planning_admins;
grant town_planning_users to town_planning_admins;
grant insert on operation to town_planning_admins;
grant insert on rule to town_planning_admins;
grant insert on rule_operation to town_planning_admins;
grant delete on operation to town_planning_admins;
grant delete on rule to town_planning_admins;
grant delete on rule_operation to town_planning_admins;
grant update on operation to town_planning_admins;
grant update on rule to town_planning_admins;
grant update on rule_operation to town_planning_admins;
