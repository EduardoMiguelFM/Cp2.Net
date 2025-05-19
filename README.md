# IDEIA DO PROJETO - CP2 - ADVANCED BUSINESS DEVELOPMENT WITH .NET

Este documento apresenta a proposta do grupo para o projeto de CP2, baseado no desafio real da Mottu.

---

## 👥 INTEGRANTES DO GRUPO
- RM555871 – Eduardo Miguel Forato Monteiro  
- RM556996 – Cícero Gabriel Oliveira Serafim

---

## 📘 TÍTULO DO PROJETO
**Sistema de Mapeamento Inteligente de Motos no Pátio – Filial São Paulo**

---

## 🎯 PROBLEMA A SER RESOLVIDO

A Mottu precisa ter total visibilidade sobre a localização de cada moto em seus pátios, garantindo rastreabilidade, controle e agilidade nas operações de retirada, devolução e manutenção.

Atualmente, o processo de controle de motos é manual e suscetível a erros humanos, o que dificulta a operação e o planejamento logístico.

---

## 💡 SOLUÇÃO PROPOSTA

Desenvolveremos uma API RESTful, baseada em .NET, para controle de motos e pátios da Mottu. O sistema permitirá:

- Cadastro e consulta de motos com status operacional
- Associação de motos a pátios específicos
- Atualização de status e localização de forma rápida
- Integração futura com sensores físicos (IoT) + Leds automáticos

Essa API será a base para uma futura plataforma completa de monitoramento em tempo real das operações nos pátios da Mottu.

---

## 📐 ENTIDADES PRINCIPAIS

- **Moto**: placa, modelo, status, pátio vinculado  
- **Pátio**: nome da unidade, setor físico dividído por cores e status da moto (ex: Setor A "Disponível", Setor B"Indisponível")

---

## 🛠 TECNOLOGIAS E ESTRUTURA

- .NET 8  
- EF Core com Oracle  
- AutoMapper + MappingConfig  
- Swagger/OpenAPI documentado  
- Clean Architecture com separação de camadas:
  - Domain
  - Application
  - Infrastructure
  - API (Presentation)

---

## 📌 OBSERVAÇÕES FINAIS

Este MVP (mínimo produto viável) será expandido no Challenge Final com novos módulos, como rastreamento, interface mobile, segurança.

---
