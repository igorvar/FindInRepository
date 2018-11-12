SELECT SiebelObject, ParentName, Name, Text, Language, Created, Updated /*, ParentInactive, Inactive, RepositoryId*/ from
(
	-- Applet SearchSpec
	select 
		'01 Applet SearchSpec' SiebelObject, 
		t1.NAME ParentName, 
		t1.NAME Name, 
		t1.SRCHSPEC Text,
		null Language,
		t1.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t1.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_APPLET t1 with (noLock)
	union
	-- Applet Browser Script
	select 
		'02 Applet Browser Script' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.SCRIPT Text,
		'JS' Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_APLT_BRSSCRPT t1 with (noLock)
		join S_APPLET t2 on t1.APPLET_ID = t2.ROW_ID

	union
	-- Applet Server Script
	select 
		'03 Applet Server Script' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.SCRIPT Text,
		PROG_LANG Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_APPL_WEBSCRPT t1 with (noLock)
		join S_APPLET t2 on t1.APPLET_ID = t2.ROW_ID
		
	union


--Applet User Properties added IgorV. 08.10.15


select '04 Applet User Properties' SiebelObject,
	t2.NAME ParentName,
	t1.NAME Name, 
	t1.VALUE Text,
	null Language,
	t2.INACTIVE_FLG ParentInactive, 
	t1.INACTIVE_FLG Inactive, 
	t2.REPOSITORY_ID RepositoryId,
	t1.CREATED as Created,
	t1.LAST_UPD as Updated
	from S_APPLET_UPROP t1 with (noLock)
	join S_APPLET t2 on t1.APPLET_ID = t2.ROW_ID

union

	-- Application Browser Script
	select 
		'05 Application Browser Script' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.SCRIPT Text,
		'JS' Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_APPL_BRSSCRPT t1 with (noLock)
		join S_APPLICATION t2 on t1.APPLICATION_ID = t2.ROW_ID
  
	union
	-- Application Server Script
	select 
		'06 Application Server Script' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.SCRIPT Text,
		PROG_LANG Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_APPL_SCRIPT t1 with (noLock)
		join S_APPLICATION t2 on t1.APPLICATION_ID = t2.ROW_ID

	union

	-- BC SearchSpec
	select 
		'07 BC SearchSpec' SiebelObject, 
		t1.NAME ParentName, 
		t1.NAME Name, 
		t1.SRCHSPEC Text,
		null Language,
		t1.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t1.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_BUSCOMP t1 with (noLock)

	union
	-- BC Browser Script
	select 
		'08 BC Browser Script' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.SCRIPT Text,
		'JS' Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_BC_BRS_SCRPT t1 with (noLock)
		join S_BUSCOMP t2 on t1.BUSCOMP_ID = t2.ROW_ID
	union

	-- BC Service Script
	select 
		'09 BC Server Script' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.SCRIPT Text,
		PROG_LANG Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_BUSCOMP_SCRIPT t1 with (noLock)
		join S_BUSCOMP t2 on t1.BUSCOMP_ID = t2.ROW_ID
	union
	

	-- BC UserProp
	select 
		'10 BC UserProp' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.VALUE Text,
		null Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_BUSCOMP_UPROP t1 with (noLock)
		join S_BUSCOMP t2 on t1.BUSCOMP_ID = t2.ROW_ID
	
	union
	
	-- Field Calculated Value
	select 
		'11 BC Field Calculated Value' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.CALCVAL Text,
		null Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_FIELD t1 with (noLock)
		join S_BUSCOMP t2 on t1.BUSCOMP_ID = t2.ROW_ID

	union
	-- Field Predefault Value
	select 
		'12 BC Predefault Value' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.PREDEFVAL Text,
		null Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_FIELD t1 with (noLock)
		join S_BUSCOMP t2 on t1.BUSCOMP_ID = t2.ROW_ID

	union
	-- Field Postdefault Value
	select 
		'13 BC Postdefault Value' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.POSTDEFVAL Text,
		null Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_FIELD t1 with (noLock)
		join S_BUSCOMP t2 on t1.BUSCOMP_ID = t2.ROW_ID
	union
	-- BC Field UserProp
	select 
		'14 BC Field UserProp' SiebelObject, 
		t3.NAME + ' . ' + t2.NAME ParentName, 
		t1.NAME Name, 
		t1.VALUE Text,
		null Language,
		left(isNull(nullif(t2.INACTIVE_FLG,'Y') + nullif(t3.INACTIVE_FLG,'Y'), 'Y'),1)  ParentInactive,		
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_FIELD_UPROP t1 with (noLock)
		join S_FIELD t2 on t1.FIELD_ID = t2.ROW_ID
		join S_BUSCOMP t3 on t2.BUSCOMP_ID = t3.ROW_ID

	
	union
	-- BS Browser functions
	select 
		'15 BS Browser function' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.SCRIPT Text,
		'JS' Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_SVC_BRS_SCRPT t1 with (noLock)
		join S_SERVICE t2 on t1.SERVICE_ID = t2.ROW_ID

	union
	-- BS Service functions
	select 
		'16 BS Server function' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.SCRIPT Text,
		PROG_LANG Language,
		t2.INACTIVE_FLG ParentInactive, 
		t1.INACTIVE_FLG Inactive, 
		t2.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_SERVICE_SCRPT t1 with (noLock)
		join S_SERVICE t2 on t1.SERVICE_ID = t2.ROW_ID

	union
	-- Link SearchSpec
	select 
		'17 Link Search Specification' SiebelObject,
		NAME ParentName,
		NAME Name,
		SRCHSPEC Text,
		null Language,
		INACTIVE_FLG ParentInactive, 
		INACTIVE_FLG Inactive,
		REPOSITORY_ID RepositoryId,
		CREATED Created,
		LAST_UPD Updated
		from S_LINK
	union
	-- WF Step IO Argument
	select 
		'18 WF Step IO Argument' SiebelObject, 
		t3.PROC_NAME + ' . ' + t2.NAME ParentName,
		t1.NAME as Name,
		t1.VAL Text,
		null Language,
		left(isNull(nullif(t2.INACTIVE_FLG,'Y') + nullif(t3.INACTIVE_FLG,'Y'), 'Y'),1)  ParentInactive,		
		'N' Inactive,
		t3.REPOSITORY_ID RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
	from S_WFR_STP_ARG t1
	join S_WFR_STP t2 on t1.STEP_ID = t2.ROW_ID
	join S_WFR_PROC t3 on t2.PROCESS_ID = t3.ROW_ID and t3.STATUS_CD = 'COMPLETED'

	union
	-- DataMap Comp SourseSearchSpech
	select
		'19 DataMap Comp SourseSearchSpech' SiebelObject, 
		t2.NAME ParentName, 
		t1.NAME Name, 
		t1.SRC_SRCHSPEC Text,
		null Language,
		'N' ParentInactive, 
		'N' Inactive, 
		null RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_INT_COMPMAP t1 with (noLock)
		join S_INT_OBJMAP t2 on t1.INT_OBJ_MAP_ID = t2.ROW_ID

	union
	-- DataMap Comp field SourceExp
	select
		'20 DataMap Comp field SourceExp' SiebelObject, 
		t3.NAME + ' . ' + t2.NAME ParentName, 
		t1.DST_INT_FLD_NAME Name, 
		t1.SRC_EXPR Text, 
		null Language,
		'N' ParentInactive, 
		'N' Inactive, 
		null RepositoryId,
		t1.CREATED as Created,
		t1.LAST_UPD as Updated
		from S_INT_FLDMAP t1 with (noLock)
		join S_INT_COMPMAP t2 on t1.INT_COMP_MAP_ID = t2.ROW_ID
		join S_INT_OBJMAP t3 on t2.INT_OBJ_MAP_ID = t3.ROW_ID

) tMain
WHERE 
Inactive = 'N' and ParentInactive = 'N' and (RepositoryId is null or RepositoryId = (select ROW_ID from S_REPOSITORY where NAME = 'Siebel Repository'))
