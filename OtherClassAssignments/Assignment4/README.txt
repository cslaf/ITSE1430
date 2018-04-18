Input File is included in the root folder of the solution, you can open any text file with the first dialog, and save the index wherever you want with the second file dialog.

Should run painlessly in Visual stuido 2017, just open the solution and hit f5.

Credit to https://github.com/msarsha/BinaryTree for the binary tree implementation. Had to change the InOrderEnumerator to check for a null tree, and added an actual search method so adding a line is o(log(n)) instead of the o(log(n)) from firstOrDefault. Otherwise their code.