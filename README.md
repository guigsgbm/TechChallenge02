# Documentação do Projeto TechChallenge02

## Visão Geral
Este projeto é uma aplicação .NET 6 que consiste em uma API, um WebApp e inclui várias etapas de configuração, implantação e automação no Azure DevOps. O guia a seguir fornece instruções detalhadas para configurar e implantar o projeto em um ambiente Azure.

## Requisitos
Antes de começar, certifique-se de ter o seguinte:
- Conta no Azure com as permissões necessárias.
- Conta no Azure DevOps com acesso ao projeto desejado.
- .NET 6 SDK instalado localmente.
- Git instalado localmente.

## Passos para Configuração e Implantação

### 1. Deploy do Azure SQL Server e Banco de Dados
- Faça login no portal Azure (https://portal.azure.com).
- Crie um novo servidor SQL e um banco de dados no Azure.
- Anote as informações de conexão, como a cadeia de conexão e as credenciais, pois serão necessárias posteriormente.

### 2. Deploy do Azure Container Registry (ACR)
- No portal Azure, crie um registro de contêineres.
- Anote o nome do registro e as credenciais de acesso.

### 3. Clone o Repositório
- Abra um terminal e execute o seguinte comando para clonar o repositório do GitHub:

  ```bash
  git clone https://github.com/guigsgbm/TechChallenge02.git

### 4. Configure as Pipelines no Azure DevOps

- No Azure DevOps, navegue até o seu projeto.

- Crie duas pipelines YAML: uma para a API e outra para o WebApp. Use os arquivos `.yaml` fornecidos no repositório como ponto de partida.

- Ajuste os arquivos YAML conforme necessário para configurar a compilação, teste e implantação de acordo com suas preferências.

### 5. Configurar Variáveis no Azure DevOps

- Dentro das pipelines YAML, verifique se as variáveis necessárias (se houver) estão configuradas corretamente. Faça os ajustes necessários no arquivo YAML para incluir as variáveis que seu projeto requer.

- Certifique-se de que todas as variáveis de ambiente, segredos ou quaisquer outras configurações específicas do seu projeto estejam definidas nas pipelines do Azure DevOps de acordo com suas necessidades.

### 6. Rodar as Pipelines

- Execute as pipelines no Azure DevOps para compilar, testar e implantar a API e o WebApp.

- Certifique-se de que as etapas de implantação estejam configuradas para implantar nos recursos do Azure apropriados, como o Azure App Service para o WebApp.

### 7. Deploy do Azure Container Instance

- Após a conclusão bem-sucedida das pipelines, você terá uma imagem do contêiner no ACR.

- No portal Azure, crie uma instância de contêiner e configure-a para usar a imagem do contêiner criada anteriormente (especificamente a tag "latest").
