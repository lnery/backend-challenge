# Solução

Foi desenvolvido uma API com a linguagem C# usando o .Net Core para resolver o problema apresentado no [backend-challenge](https://github.com/itidigital/backend-challenge)

O projeto Validation implementa a classe PasswordValidation, esta é responsável em validar a senha e retornar o boolean indicando se a senha é valida ou não. Esta camada foi implementada para ser testável. O projeto de Teste fará referencia e consumo das implementações realizadas nesta camada.

Também foi construído uma extensão para a classe PasswordValidation para testar a força da senha.

O projeto API expõe 2 apis conforme abaixo:
- PATH: Password/Validate, METHOD: POST
- PATH: Password/PasswordStrength, METHOD: GET

O projeto Validation.Test implementa os possíveis cenários de testes de validação da senha.


## Execução da API

Para executar a API é nessário possuir o [CLI do .Net Core](https://dotnet.microsoft.com/download/dotnet/5.0) instalado em sua máquina.


Realizar o download do codigo fonte e executar os comandos abaixo na mesma pasta do download. Se você optou por fazer o download do arquivo zip, descompacte o arquivo antes.

```bash
cd /src/API
dotnet restore
dotnet run
```

## Uso

Executar a URL [https://localhost:5001/swagger](https://localhost:5001/swagger) pelo browser.

Se ocorrer a mensagem "Sua conexão não é particular", é porque estamos estamos executando um site com segurança HTTPS e nesse momento não possuímos um certificado HTTPS valido. Clique em Avançado e depois em "Ir para localhost (não seguro)".

#### Para testar a API de Validação da Senha.

- Clique em cima do POST /Password/Validate, depois clique em Try it out, informe a senha no campo Password e clique em executar. O retorno da Validação da senha aparecerá no Response body. Se retornar true, a senha é valida, caso contrário a senha é invalida.

#### Para testar a API de Validação da Força Senha.

- Clique em cima do GET /Password//Password/PasswordStrength, depois clique em Try it out, informe a senha no campo Password e clique em executar. O retorno da Validação da força da senha aparecera no Response body.

## Teste
Para testar a validação da senha seguir os passos abaixo:

```bash
cd /test/Validation.Test
dotnet restore
dotnet test
```



## Licença
[MIT](https://choosealicense.com/licenses/mit/)
