all:
	make permutations
	make main

permutations: permutationsGenerator.c
	gcc -o perm.o permutationsGenerator.c

main: scrabbleCheat.c
	gcc -o scrabble.o scrabbleCheat.c
	gcc -o scrabble scrabble.o perm.o
