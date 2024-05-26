![image](https://github.com/Paulo-PM/Csharp-Lua/assets/37181425/37b12d35-a8d0-467c-a301-03cd795f5cd0)
O programa tem uma interface feita em C# .NET, inicialmente ele procura no mesmo diretorio uma arquivo database.lua
- o arquivo database.lua contém as funcões que manipulam os numeros passados pela interface
- Note que a interface apenas recebe 2 numeros, é no arquivo database.lua que você pode pode dizer como manipular
esses numeros, em seguida o resultado é mostrado no programa.
![image](https://github.com/Paulo-PM/Csharp-Lua/assets/37181425/c3459757-a4fa-4628-ae89-75d8c1c17b4a)
- O arquivo database.lua é monitorado em tempo real, dessa forma assim que ele for movido do diretorio
o programa avisa e reflete essa mudança, basta que ele seja movido de volta a raiz para que tudo volte ao normal
![image](https://github.com/Paulo-PM/Csharp-Lua/assets/37181425/f7a7870d-0791-4fd7-8915-57f0e12e253b)
- Como pode ser observado o programa c# envia os numeros para função "Operacao(a, b)", mas qualquer outra funçao pode ser chamada
dentro dela, como no exemplo acima que chama um função de multiplicação.
- Outras funções podem ser escritas no arquivo database.lua e chamadas dentro da função "Operacao(a, b)" sem que qualquer mudança
- seja necessaria em outro lugar
