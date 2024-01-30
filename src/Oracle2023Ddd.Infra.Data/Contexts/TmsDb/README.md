## Banco de dados

Abra o "Package Manager Console" e selecione o projeto "Oracle2023Ddd.Infra.Data" como opção do "Default project"

Comando para gerar uma nova migration
```bash
Add-Migration NomeDaMigration -Context TmsDbContext -OutputDir Contexts/TmsDb/Migrations
```
Para aplicar a nova migration no banco de dados.
```bash
Update-Database -Context TmsDbContext
```

Para desfazer a ultima migration.
```bash
Update-Database NomeDaPenultimaMigration -Context TmsDbContext
Remove-Migration -Context TmsDbContext
```

Documentação das [migrations.](https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/)
