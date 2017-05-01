create table info_schemes(
scheme_id int not null primary key,
scheme_name varchar(100)
);
create sequence info_schemes_seq start with 1 increment by 1 cache 2;

create trigger info_schemes_trg
before insert on info_schemes
for each row
begin
    if :new.scheme_id is null then
        select info_schemes_seq.nextval into :new.scheme_id from dual;
    end if;
end;

commit;

create table info_tables(
table_id int not null primary key,
table_name varchar(100),
scheme_id int not null,
primary_column_name varchar(100),
foreign key(scheme_id) references info_schemes(scheme_id)
);

create sequence info_tables_seq start with 1 increment by 1 cache 2;

create trigger info_tables_trg
before insert on info_tables
for each row
begin
    if :new.table_id is null then
        select info_tables_seq.nextval into :new.table_id from dual;
    end if;
end;

commit;

create table info_objects(
object_id int not null primary key,
table_id int not null,
table_object_id int not null,
foreign key(table_id) references info_tables(table_id)
);

create sequence info_objects_seq start with 1 increment by 1 cache 2;

create trigger info_objects_trg
before insert on info_objects
for each row
begin
    if :new.object_id is null then
        select info_objects_seq.nextval into :new.object_id from dual;
    end if;
end;
commit;

create table info_attributes(
attribute_id int not null primary key,
attribute_name varchar(100),
table_id int not null,
data_type varchar(20),
foreign key(table_id) references info_tables(table_id)
);

create sequence info_attributes_seq start with 1 increment by 1 cache 2;

create trigger info_attributes_trg
before insert on info_attributes
for each row
begin
    if :new.attribute_id is null then
        select info_attributes_seq.nextval into :new.attribute_id from dual;
    end if;
end;
commit;

create sequence info_session_seq start with 1 increment by 1 cache 2;

create table info_session(
session_id int not null primary key,
creation_date date not null);

create trigger info_session_trg
before insert on info_session
for each row
begin
    if :new.session_id is null then
        select info_session_seq.nextval into :new.session_id from dual;
    end if;
end;
commit;

create sequence info_cache_seq start with 1 increment by 1 cache 2;

create table info_cache(
cache_id int not null primary key,
session_id int not null,
attribute_id int not null,
object_id int not null,
str_val varchar2(2000),
number_val number,
date_val date,
foreign key(session_id) references info_session(session_id),
foreign key(attribute_id) references info_attributes(attribute_id),
foreign key(object_id) references info_objects(object_id));

create trigger info_cache_trg
before insert on info_cache
for each row
begin
    if :new.cache_id is null then
        select info_cache_seq.nextval into :new.cache_id from dual;
    end if;
end;
commit;