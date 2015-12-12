--delete from URLData
select count(distinct URL) from UrlData
select count(*) from UrlData where Visited=1
select count(*) from UrlData where Visited=0

--select top 10000 * from UrlData order by URL