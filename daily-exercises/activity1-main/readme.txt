File Joiner

Usage :  FileJoin <first file> <second file>  <output file>

The application will collate the two files and write the output to the output file. 
	- The first file will contain userid and name. 
	- The second file will contain the userid and last name

E.g.

File 1
1 James
2 Robert
4 Curly
3 Sunny

File 2
4 Santos
2 Dewright
3 Crammes
1 Filomeno

Output
1 James Filomeno
2 Robert Dewright
3 Sunny Crammes
4 Curly Santos

---

File 1
1 James
2 Robert
3 Sunny

File 2
4 Santos
3 Crammes
1 Filomeno

Output
1 James Filomeno
2 Robert ---
3 Sunny Crammes
4 --- Santos
