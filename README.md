# Gestão de Motoboys

Aplicativo de console em C# para registrar motoboys e acompanhar o status de cada um em tempo real.

## Funcionalidades 

- **Registrar motoboy:** cadastro com nome e telefone, com validação de nome em branco e de nome duplicado
- **Listar motoboys:** mostra todos os motoboys cadastrados
- **Alterar status:** muda o status do motoboy entre *Disponível na Base*, *Em Rota de Entrega* e *Retornando para a Base*
- **Relatório por status:** filtra os motoboys por status ou mostra todos
- **Sair:** encerra o sistema

## como rodar 

git clone SSH: git@github.com:lucasmrandrade/Gestao-de-Motoboy-no-console.git

git clone HTTTPS: https://github.com/lucasmrandrade/Gestao-de-Motoboy-no-console.git

na pasta há um executável Gestao-de-Motoboy-no-console/bin/Release/net10.0/win-x64
/publish

só baixar esse MotoboyEntregas.exe que ele roda em qualquer computador com sistema operacional Windows 

## Como usar 

Ao iniciar, o menu principal aparece com as opções de 1 a 5. Digite o número da opção desejada e siga as instruções na tela.

Os nomes são salvos em maiúsculas, então "joão" e "JOÃO" contam como o mesmo motoboy.

## Observações

Os dados ficam apenas na memória (`Dictionary`), então são perdidos ao fechar o programa.

e como esse projeto é uma base lógica da construção da API, ele e um seguimento da lógica e regra  de negócio que será seguido com base nesse console criado, contudo, poderá ter mudanças na regra no futuro. 

## Tecnologias

- C#
- .NET

