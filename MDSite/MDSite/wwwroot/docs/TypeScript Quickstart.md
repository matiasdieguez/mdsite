# TypeScript Quickstart

- Install NodeJS [https://nodejs.org/en/](https://nodejs.org/en/)
- Install VS Code [https://code.visualstudio.com/](https://code.visualstudio.com/)
- Install MongoDB 
- Install NestJS for Server Side (Backend) stack
```
npm i -g @nestjs/cli
```
- Install React for Frontend Side (Frontend) stack


## VS Code commands

    - F5 starts Debug (selected project)
    - Ctrl+Shift+B start Build
    - Ctrl+Shift+ñ open Terminal


## Install dependencies
```
npm install
```

## Running the app

```bash
# development
$ npm run start

# watch mode
$ npm run start:dev

# production mode
$ npm run start:prod
```

## Test

```bash
# unit tests
$ npm run test

# e2e tests
$ npm run test:e2e

# test coverage
$ npm run test:cov
```


## Backend CLI project creation
NestJS API Server
```
nest new dummy-api
```

NestJS CRUD Scaffolding
```
nest g resource dummy
```
