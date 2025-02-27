**Passos para executar o projeto**

Verificar a string de conexão com o banco de dados no arquivo web.config do projeto Skynetz.WebUI.

Executar o comando update-database no package manager console sendo selecionado o projeto Skynetz.Infra.Data.

**Informações de uso**

Contém três telas de consultas, verificar as tarifas, planos e a consulta de valores com e sem planos "FaleMais".

As telas de tarifas e planos, basta clicar nos menu superior que exibe o grid com as informações.

A tela de consulta, contém quatro compos, sendo três para selecionar, a origem, destino e plano, e um para digitar a quantidade de minutos.

**Sobre a estrutura do projeto**

Foi separado em camadas, apresentação (WebUI), aplicação, Infra data e domínio.

O banco de dados, são duas tabelas, tarifa e plano. Utilizado EntityFramework.

Foram separados as responsabilidades de cada camada.