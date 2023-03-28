select * into #t1 from (select 1 col1, 'ABC' col2)t

select * from #t1

select 1 col1, 'ABC' col2
UNION ALL
select 2 col1, 'DEF' col2