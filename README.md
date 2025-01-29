# CPF Validator - Serverless   

Microsserviço serverless para validação de CPFs, otimizado para escalabilidade e baixo custo com **Azure Functions**.  

## Tecnologias  
- **.NET & C#**  
- **Azure Functions**  
- **Serverless Architecture**  

## 📦 Instalação  
1. Clone o repositório:  
   ```sh
   git clone https://github.com/seu-usuario/cpf-validator-serverless.git
   cd cpf-validator-serverless
   ```
2. Instale as dependências:  
   ```sh
   dotnet restore
   ```
3. Execute a função localmente:  
   ```sh
   func start
   ```

## 📌 Endpoints  
### ✅ **Validação de CPF**  
- **`POST /api/fnvalidacpf`**  
  - **Body (JSON):**  
    ```json
    {
      "cpf": "12345678909"
    }
    ```
  - **Resposta:**  
    CPF válido

## ☁️ Deploy no Azure  
1. Faça login:  
   ```sh
   az login
   ```
2. Publique a função:  
   ```sh
   func azure functionapp publish <NOME_DA_FUNCAO>
   ```
