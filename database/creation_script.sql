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
scheme_id int not null,
foreign key(table_id) references object_type(object_type_id),
foreign key(scheme_id) references info_schemes(scheme_id)
);

commit;

create table info_objects(
object_id int not null primary key,
foreign key(object_id) references object(object_id)
);

commit;

create table info_attributes(
attribute_id int not null primary key,
data_type varchar2(20),
foreign key(attribute_id) references attribute_type(attribute_type_id)
);

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

create table info_operation(
operation_id int not null primary key,
first_table_id int not null,
second_table_id int not null,
operation_name varchar2(30) not null,
operation_procedure varchar2(30) not null,
foreign key(first_table_id) references info_tables(table_id),
foreign key(second_table_id) references info_tables(table_id));

create sequence info_operation_seq start with 1 increment by 1 cache 2;

create trigger info_operation_trg
before insert on info_operation
for each row
begin
    if :new.operation_id is null then
        select info_operation_seq.nextval into :new.operation_id from dual;
    end if;
end;

commit;