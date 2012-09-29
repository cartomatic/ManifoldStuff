Sometimes when you get data as gml coordinates are swapped.
This is a simple script written in c# that swaps the x and y.
There is also a query that does the same thing but much quicker (test it ;-).
Although there is a little problem with this query - it works great and is much faster than the script for small amounts of data (something like a few tens of thousands of objects)
but becomes rather slowish for larger datasets (something like 500k recs).
The solution is to write a script that will make the query work with a subset of the source dataset at a time and repeat it for the whole dataset.