# Changelog

Registro de alterações e progresso do sistema.

## [0.0.5] - 2020-02-24

### Added:

- Inicialização do projeto para [front-end]
- Interface (View) para cadastro de contatos
- Validações no cadastro de contatos

## [0.0.4] - 2020-02-17

### Added:

- [Migração] para banco de dados no Azure (temporário/teste)
- Implantação da Api no Azure (https://agenda-invent.azurewebsites.net)

## [0.0.3] - 2020-02-16

### Added

- [Mensagens de confirmação]
- [Resolução de dependencias] na Api
- Configuração do [OAuth na API] (autorização sem login)
- [Compressão] e cache (cache desabilitado por padrão)
- [Método Get] para lista de contatos

### Changed

- Mensagem de erro para contato existente
- Removida unicidade do atributo Name

### Removed

- Projeto Test (obsoleto)

## [0.0.2] - 2020-02-11

### Added

- [Dependency resolver]
- [Service pattern]

### Fixed

- Retorno dos métodos .Get* do [repositório](https://github.com/lucasdemoraesc/agenda-invent/blob/master/AgendaInvent.Infrastructure/Repositories/ContactRepository.cs) (.First() -> .FirstOrDefault())

### Changed

- Atualização das [mensagens de erro]
- [Nome das pastas] (agendaInvent -> AgendaInvent)

### Removed

- Atributo email
- Busca e validação de email
- Uso do método Update nas camadas superiores

### Deprecated
- Projeto "test" (Reimplementado usando padrões diferentes, deverá ser removido futuramente)

### Notes

- O uso do método Update deve ser reimplementado nas camadas superiores futuramente

## [0.0.1] - 2020-02-10

### Added

- [Domínio] da aplicação, agenda de contatos com capacidade de cadastrar, remover contatos e procurar contatos
- [Validações] e tratamento de erros
- [Mapeamento de dados] utilizando o entity framework

### Deprecated

- Projeto de [testes]

[0.0.1]: https://github.com/lucasdemoraesc/agenda-invent/releases/tag/v0.0.1
[0.0.2]: https://github.com/lucasdemoraesc/agenda-invent/compare/v0.0.1...v0.0.2
[0.0.3]: https://github.com/lucasdemoraesc/agenda-invent/compare/v0.0.2...v0.0.3
[0.0.4]: https://github.com/lucasdemoraesc/agenda-invent/compare/v0.0.3...v0.0.4
[0.0.5]: https://github.com/lucasdemoraesc/agenda-invent/compare/v0.0.4...v0.0.5

[Dependency resolver]: https://github.com/lucasdemoraesc/agenda-invent/blob/master/AgendaInvent.Startup/DependencyResolver.cs
[Service pattern]: https://github.com/lucasdemoraesc/agenda-invent/blob/master/AgendaInvent.Business/Services/ContactService.cs
[mensagens de erro]: https://github.com/lucasdemoraesc/agenda-invent/tree/master/AgendaInvent.Common/Resources
[Nome das pastas]: https://github.com/lucasdemoraesc/agenda-invent
[Domínio]: https://github.com/lucasdemoraesc/agenda-invent/tree/master/AgendaInvent.Domain
[Validações]: https://github.com/lucasdemoraesc/agenda-invent/tree/master/AgendaInvent.Common
[Mapeamento de dados]: https://github.com/lucasdemoraesc/agenda-invent/tree/master/AgendaInvent.Infrastructure/Data
[testes]: https://github.com/lucasdemoraesc/agenda-invent/tree/master/AgendaInvent.Test
[Mensagens de confirmação]: https://github.com/lucasdemoraesc/agenda-invent/tree/master/AgendaInvent.Common/Resources
[Resolução de dependencias]: https://github.com/lucasdemoraesc/agenda-invent/blob/master/AgendaInvent.Api/Helpers/UnityResolver.cs
[OAuth na API]: https://github.com/lucasdemoraesc/agenda-invent/blob/master/AgendaInvent.Api/Security/AuthorizationServerProvider.cs
[Compressão]: https://github.com/lucasdemoraesc/agenda-invent/blob/master/AgendaInvent.Api/Helpers/CompressionHelper.cs
[Método Get]: https://github.com/lucasdemoraesc/agenda-invent/blob/master/AgendaInvent.Api/Controllers/ContactsController.cs
[Migração]: https://github.com/lucasdemoraesc/agenda-invent/tree/master/AgendaInvent.Infrastructure/Migrations
[front-end]: https://github.com/lucasdemoraesc/agenda-invent/tree/master/agendainvent
