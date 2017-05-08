-- Создание таблицы для хранения владельца таблиц

--Создаем таблицу info_schemes
create table info_schemes(
scheme_id int not null primary key,
scheme_name varchar(100)
);

-- Создаем последовательность для генерации первичных ключе таблицы info_schemes
create sequence info_schemes_seq start with 1 increment by 1 cache 2;

-- Создаем триггер для таблицы info_schemes, которые при добавлении кортежа если не установлен первичный ключ генерирует его
create trigger info_schemes_trg
before insert on info_schemes
for each row
begin
    if :new.scheme_id is null then
        select info_schemes_seq.nextval into :new.scheme_id from dual;
    end if;
end;

commit;

-- Создаем последовательность для генерации первичных ключе таблицы object_type;
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

-- Создаем таблицу info_tables. Храним название таблиц, которые будут использовать в анализе.
create table info_tables(
table_id int not null primary key,
scheme_id int not null,
foreign key(table_id) references object_type(object_type_id),
foreign key(scheme_id) references info_schemes(scheme_id)
);

commit;

-- Создаем последовательность для генерации первичных ключей таблицы object;
create sequence object_seq
increment by 1
start with 1
cache 2;

-- Создаем таблицу object, для хранения объектов доступных для анализа.
create table object(
object_id int not null primary key,
object_type_id int not null,
object_value int not null,
foreign key(object_type_id) references object_type(object_type_id));

-- создаем триггер для таблицы object. Он генерирует первичный ключ таблицы, если при добавление кортежа он отсутствует.
create trigger object_trg
before insert on object
for each row
begin 
    if :new.object_id is null then
        select object_seq.nextval into :new.object_id from dual;
    end if;
end;

-- Создаем таблицу info_objects для хранения объектов которые будут использовать при анализе.
create table info_objects(
object_id int not null primary key,
foreign key(object_id) references object(object_id)
);

commit;

-- Создаем последовательность для генерации первичных ключей таблицы info_session;
create sequence info_session_seq start with 1 increment by 1 cache 2;

-- Создаем таблицу info_session для хранение информации по сессии анализа.
create table info_session(
session_id int not null primary key,
creation_date date not null);

-- создаем триггер для таблицы object. Он генерирует первичный ключ таблицы, если при добавление кортежа он отсутствует.
create trigger info_session_trg
before insert on info_session
for each row
begin
    if :new.session_id is null then
        select info_session_seq.nextval into :new.session_id from dual;
    end if;
end;

commit;

-- Создаем последовательность для генерации первичных ключей таблицы attribute_type
create sequence attribute_type_seq
increment by 1
start with 1
cache 2;

-- создаем таблицу attribute_type, в которой хранятся метаданные по атрибутам таблиц доступных для анализа.
create table attribute_type(
attribute_type_id int not null primary key,
attribute_name varchar2(15) not null,
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


-- Создаем последовательность для генерации первичных ключей таблицы info_cache;
create sequence info_cache_seq start with 1 increment by 1 cache 2;

-- Создаем таблицу info_cache, для хранения значений атрибутов.
create table info_cache(
cache_id int not null primary key,
session_id int not null,
attribute_id int not null,
object_id int not null,
str_val varchar2(2000),
number_val number,
date_val date,
foreign key(session_id) references info_session(session_id),
foreign key(attribute_id) references attribute_type(attribute_type_id),
foreign key(object_id) references info_objects(object_id));

-- cоздаем триггер для таблицы info_cache. генерирует первичный ключ таблицы, если при добавление кортежа он отсутствует.
create trigger info_cache_trg
before insert on info_cache
for each row
begin
    if :new.cache_id is null then
        select info_cache_seq.nextval into :new.cache_id from dual;
    end if;
end;

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
second_object_type_id int not null,
operation_name varchar2(15) not null,
operation_procedure varchar2(15) not null,
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
foreign key(operation_id) references operation(operation_id));
commit;