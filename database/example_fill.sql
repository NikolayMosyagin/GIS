insert into owner(owner_name)
values('KALININGRAD_UAG');
commit;

insert into object_type(object_name, owner_id, is_geo, theme_name, geo_object_name)
values('BUILDINGS', 1, 0, 'KLG_BUILDINGS', 'GEO_BUILDINGS_AREA');

insert into object_type(object_name, owner_id, is_geo, theme_name, geo_object_name)
values('PARCELS', 1, 0, 'KLGD_GEO_PARCELS', 'GEO_PARCELS');

insert into object_type(object_name, owner_id, is_geo, theme_name)
values('GEO_BUILDINGS_AREA', 1, 1, 'KLG_GEO_BUILDINGS_AREA');

insert into object_type(object_name, owner_id, is_geo, theme_name)
values('GEO_PARCELS', 1, 1, 'KLGD_GEO_PARCELS');

commit;


insert into attribute_type(attribute_name, object_type_id)
values('FLOORS', 1);
insert into attribute_type(attribute_name, object_type_id)
values('FUNCTIONALITY_GROUPS_ID', 3);
insert into attribute_type(attribute_name, object_type_id)
values('GEOMETRY', 3);
insert into attribute_type(attribute_name, object_type_id)
values('GEOMETRY', 4);

commit;

grant town_planning_users to kaliningrad_uag;
grant town_planning_admins to town_planning_code;