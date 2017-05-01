insert into object_type(object_name)
values('BUILDINGS');
insert into object_type(object_name)
values('STREETS');
commit;

insert into object(object_type_id, object_value)
values(1, 17501);
insert into object(object_type_id, object_value)
values(1, 17567);
insert into object(object_type_id, object_value)
values(2, 408);
insert into object(object_type_id, object_value)
values(2, 416);
commit;