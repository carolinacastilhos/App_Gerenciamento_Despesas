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

### Demonstração de algumas funcionalidades e validações

<div align="center"><img src="https://github.com/carolinacastilhos/App_Gerenciamento_Despesas/assets/117789578/1a587b71-38ab-4d9a-b474-5d9a724ce1d7" width="200px" /></div>

<div align="center"><img src="https://github.com/carolinacastilhos/App_Gerenciamento_Despesas/assets/117789578/37b5f8c2-9dd5-41f1-9d3b-fd819880514d" width="200px" /></div>

<div align="center"><img src="https://github.com/carolinacastilhos/App_Gerenciamento_Despesas/assets/117789578/5ba9a010-f7f4-43ff-8fbe-45e44087924c" width="200px" /></div>

<div align="center"><img src="https://github.com/carolinacastilhos/App_Gerenciamento_Despesas/assets/117789578/ddae8ee3-000c-4e16-9f68-ef09f97c3689" width="200px" /></div>

<div align="center"><img src="https://github.com/carolinacastilhos/App_Gerenciamento_Despesas/assets/117789578/a828298d-2a81-42b7-afe8-675e27a14a86" width="200px" /></div>

<div align="center"><img src="https://github.com/carolinacastilhos/App_Gerenciamento_Despesas/assets/117789578/437f121e-da4c-4e28-a446-6bc4d1f1bb58" width="200px" /></div>

<div align="center"><img src="https://github.com/carolinacastilhos/App_Gerenciamento_Despesas/assets/117789578/8e6f87c3-3882-4b55-bdeb-9a9c5483b423" width="200px" /></div>

<div align="center"><img src="https://github.com/carolinacastilhos/App_Gerenciamento_Despesas/assets/117789578/d62e40c5-603f-4c36-a267-f7e2f59f4790" width="200px" /></div>

<div align="center"><img src="https://github.com/carolinacastilhos/App_Gerenciamento_Despesas/assets/117789578/b54fe3c8-61ec-408e-b84c-c0404f06199a" width="200px" /></div>

<div align="center"><img src="https://github.com/carolinacastilhos/App_Gerenciamento_Despesas/assets/117789578/12b6e882-3467-42b6-a493-042a1459904d" width="200px" /></div>

<div align="center"><img src="https://github.com/carolinacastilhos/App_Gerenciamento_Despesas/assets/117789578/2fad2bac-e0bd-48dc-9035-89a36f0e3f83" width="200px" /></div>

### Execução da Aplicação

Para acessar a aplicação basta realizar o clone do repositório e rodar o arquivo GerenciamentoDespesas.exe.
Caminho do Arquivo: GerenciamentoDespesas\bin\Debug\net6.0\GerenciamentoDespesas.exe

### Tecnologias utilizadas

- Linguagem de programação C#
- IDE Visual Studio
- JSON (Javascript Object Notation)
- POO (Programação Orientada a Objetos)
