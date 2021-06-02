**SISTEMA DE CADASTRO DE MAQUINAS COPAVE**

---

**Especificações**

- O Sistema foi desenvolvido com asp.net MVC na versão 5.0.202 do SDK e .Net framework, EntityFramework versão 5.0.5 e Layout com detalhes em BootsTrap Versão 3.0 . As validações foram feitas diretamente no Model utilizando **_DataAnnotations_**

- O SDK pode ser baixado aqui: https://dotnet.microsoft.com/download/dotnet/5.0

- A IDE utilizada foi o Visual Studio Code, ferramenta gratuíta da Microsoft.

- O Banco de dados utlilizado foi o SQL Server, versão 12, porém pode ser executado em praticametne todas as versões.

- Segue um Sscript para a criação do banco de dados arquivo: Script_Banco_E_Usuários.sql. Nele, já deixei a opção de criar os usuários do banco e de conexão. O objetivo foi acompanhar as configurações de contexto do Sistema.

**Execução**

Para executar o projeto, basta baixar o SDK, o (Opciaonal) Visual Studio Code ou Visual Studio, abrir o projeto e executar ou seguir os passos abaixo.

Embora não solicitado, adicionei uma tela para a inclusão do TIPO DE MAQUINA, dessa forma os tipos de máquinas seguirão um padrão previamente definido.

Da mesma forma agi ao manter o número da maquina como chave criada automaticamente pelo banco de dados, embora entendo que em algumas situações seja necessário manter um número para disposição das maquinas no layout da fabrica ou em setores distintos.

**Observação**

Para executar o projeto sem as IDEs, basta descompacta-lo em um diretório Abra o terminal de comando **CMD** ou **PowerScript** acessar o diretório do projeto ./copave, utilizando os comandos:

- **cd copave**, em seguida utilize o comando:
- **dotnet restore** para o sistema restaurar as referencias do projeto em seguida execute o usando o comando:
- **dotnet run** o sistema irá disponibilizar 2 endereços para acesso, um utilizando o protocolo **https** e outro utilizando o **http** normal.

**_NO FINAL DEVE APARECER ALGO COMO SEGUE_**

```
PS C:\Projetos\copave> dotnet watch run
watch : Started
Building...
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Projetos\copave
```

---

**_USO DAS TECNOLOGIAS_**

Desenvolvido com asp.NET MVC 5.0 **C#** e**Bootstrap**

---

**OBRIGADO**
