<h1 align="center"> Gerenciamento de Despesas Pessoais </h1>

### Descrição

A solução consiste em uma aplicação console para gerenciamento de despesas,
desenvolvida na linguagem C# com a IDE Visual Studio, em inglês. A aplicação é
manipulada por somente um usuário que pode adicionar diversas contas. Ao iniciar,
aparece o menu principal com 3 funcionalidades gerais, além da opção de saída do aplicativo:
gerenciar contas, transações e painel geral.
Na opção gerenciar contas, entramos em um segundo menu, onde pode-se optar em
incluir uma nova conta ou remover uma conta. A persistência das contas e suas
transações ocorrem através de um arquivo JSON.
Nas transações, encontramos um menu com a primeira opção sendo a de incluir uma
transação. Ao selecionarmos esta opção, precisamos informar a conta na qual queremos
incluir a transação e demais informações sobre a transação, como data, tipo (despesa ou
receita), valor, entre outras. Se for do tipo despesa, o valor da transação é subtraído do
saldo da conta assim como se for receita, o valor é somado. A segunda opção deste
menu de transações é a de mostrar todas as transações de uma conta. Ao entrar nesta
opção, informamos uma conta, e assim aparece todas as transações existentes nela.
Por fim, há a opção do menu principal de painel geral, na qual ao entrarmos,
conseguimos observar todas as contas que estão cadastradas na aplicação, seus saldos
individuais e o saldo total de todas as contas associadas.

<!-- ### Demonstração de algumas funcionalidades e validações -->

### Execução da Aplicação

Para acessar a aplicação basta realizar o clone do repositório e rodar o arquivo GerenciamentoDespesas.exe.
Caminho do Arquivo: GerenciamentoDespesas\bin\Debug\net6.0\GerenciamentoDespesas.exe

### Tecnologias utilizadas

- Linguagem de programação C#
- IDE Visual Studio
- JSON (Javascript Object Notation)
- POO (Programação Orientada a Objetos)
