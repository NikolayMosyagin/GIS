-- Создаем последовательности для генерации первичных ключей

-- для таблицы attribute_type
create sequence attribute_type_seq
increment by 1
start with 1
cache 2;

-- для таблицы object_type
create sequence object_type_seq
increment by 1
start with 1
cache 2;

-- создаем таблицу object_type, в которой хранятся метаданные по объектам
create table object_type(
object_type_id int not null primary key,
object_name varchar2(15) not null);

-- создаем триггер для таблицы object_type. Он генерирует первичный ключ таблицы, если при добавление кортежа он отсутствует.
create trigger object_type_trg
before insert on object_type
for each row
begin 
    if :new.object_type_id is null then
        select object_type_seq.nextval into :new.object_type_id from dual;
    end if;
end;

-- создаем таблицу attribute_type, в которой хранятся метаданные по атрибутам
create table attribute_type(
attribute_type_id int not null primary key,
attribute_name varchar2(15) not null,
attribute_type varchar2(15) not null,
object_type_id int not null,
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
