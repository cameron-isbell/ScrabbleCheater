#include<stdio.h>
#include<ctype.h>

int main (int argc, char* argv[]) { 
    const short maxLtrs = 8;
    const short maxWrdLn = 30;
    char letters[maxLtrs];
    
    while (1) {
        /*
            TODO: IMPLEMENT BOARD
            TODO: IMPLEMENT WORD FINDING
            TODO: IMPLEMENT BOARD SEARCHING
        */
        
        fgets(letters, maxLtrs, stdin);
        for (int i = 0; i < maxLtrs; i++) {
            if (letters[i] == '\n' || letters[i] == '\r')  {
                letters[i] = '\0';
                break;
            }
            letters[i] = toupper(letters[i]);
        }

        FILE* dict = fopen("dictionary.txt", "r");
        
        

        char word[30];
        while (fgets(word, maxWrdLn, dict)) {
            
        }
        break;

    }
}