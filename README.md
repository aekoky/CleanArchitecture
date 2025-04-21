<p align="center"><h1 align="center">CLEANARCHITECTURE</h1></p>
<p align="center">
	<em><code>❯ AEKOKY Rida</code></em>
</p>
<p align="center">
	<img src="https://img.shields.io/github/license/aekoky/CleanArchitecture?style=default&logo=opensourceinitiative&logoColor=white&color=0080ff" alt="license">
	<img src="https://img.shields.io/github/last-commit/aekoky/CleanArchitecture?style=default&logo=git&logoColor=white&color=0080ff" alt="last-commit">
	<img src="https://img.shields.io/github/languages/top/aekoky/CleanArchitecture?style=default&color=0080ff" alt="repo-top-language">
	<img src="https://img.shields.io/github/languages/count/aekoky/CleanArchitecture?style=default&color=0080ff" alt="repo-language-count">
</p>
<p align="center"><!-- default option, no dependency badges. -->
</p>
<p align="center">
	<!-- default option, no dependency badges. -->
</p>
<br>

##  Table of Contents

- [ Overview](#-overview)
- [ Features](#-features)
- [ Project Structure](#-project-structure)
  - [ Project Index](#-project-index)
- [ Getting Started](#-getting-started)
  - [ Prerequisites](#-prerequisites)
  - [ Installation](#-installation)
  - [ Usage](#-usage)
  - [ Testing](#-testing)
- [ Project Roadmap](#-project-roadmap)
- [ Contributing](#-contributing)
- [ License](#-license)
- [ Acknowledgments](#-acknowledgments)

---

##  Overview

<code>CleanArchitecture is a full-stack boilerplate built with .NET Core, Angular, and Docker, following the principles of Clean Architecture and the CQRS pattern. It features a modular backend with MediatR and EF Core, a reactive frontend using Angular + NgRx, and is powered by Kong Gateway for scalable API management. Perfect for building enterprise-grade, maintainable applications.</code>

---

##  Features

### Backend (.NET Core + EF Core)
- Clean Architecture (Domain → Application → Infrastructure → API)
- CQRS with [MediatR](https://github.com/jbogard/MediatR)
- Entity Framework Core for data access
- FluentValidation for input validation
- Swagger for API documentation

### Frontend (Angular + NgRx + RxJS)
- Angular 19
- NgRx Store, Effects, Actions for reactive state management
- RxJS for async flows
- Angular Service Worker for PWA features (offline, caching)
- Modular architecture with lazy loading

### DevOps & Gateway
- Dockerized API, Angular app, database, and Kong Gateway
- Kong handles routing, authentication, logging, and more
- MSSQL as the database backend

---

##  Project Structure

```sh
└── CleanArchitecture/
    ├── AngularClient
    │   ├── .editorconfig
    │   ├── .gitignore
    │   ├── .postcssrc.json
    │   ├── .vscode
    │   ├── AngularClient.esproj
    │   ├── Dockerfile
    │   ├── README.md
    │   ├── angular.json
    │   ├── ngsw-config.json
    │   ├── nswag.json
    │   ├── package-lock.json
    │   ├── package.json
    │   ├── public
    │   ├── src
    │   ├── tsconfig.app.json
    │   ├── tsconfig.json
    │   └── tsconfig.spec.json
    ├── CleanArchitecture.sln
    ├── Kong
    │   ├── config
    │   └── declarative
    ├── WebApi
    │   ├── Application
    │   ├── Domain
    │   ├── Infrastructure
    │   ├── Persistence
    │   └── WebApi
    ├── docker-compose.dcproj
    ├── docker-compose.override.yml
    ├── docker-compose.yml
    ├── global.json
    ├── launchSettings.json
    └── secrets.json
```


###  Project Index
<details open>
	<summary><b><code>CLEANARCHITECTURE/</code></b></summary>
	<details> <!-- __root__ Submodule -->
		<summary><b>__root__</b></summary>
		<blockquote>
			<table>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/launchSettings.json'>launchSettings.json</a></b></td>
				<td><code>Visual Studio configuration file</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/docker-compose.dcproj'>docker-compose.dcproj</a></b></td>
				<td><code>Docker Compose project file</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/global.json'>global.json</a></b></td>
				<td><code>.NET SDK configuration for CLI commands</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/docker-compose.override.yml'>docker-compose.override.yml</a></b></td>
				<td><code>Docker Compose YAML configuration file for development</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/CleanArchitecture.sln'>CleanArchitecture.sln</a></b></td>
				<td><code>CleanArchitecture solution file</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/docker-compose.yml'>docker-compose.yml</a></b></td>
				<td><code>Docker Compose YAML configuration file</code></td>
			</tr>
			</table>
		</blockquote>
	</details>
	<details> <!-- AngularClient Submodule -->
		<summary><b>AngularClient</b></summary>
		<blockquote>
			<table>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/tsconfig.spec.json'>tsconfig.spec.json</a></b></td>
				<td><code>❯ REPLACE-ME</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/ngsw-config.json'>ngsw-config.json</a></b></td>
				<td><code>❯ REPLACE-ME</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/package-lock.json'>package-lock.json</a></b></td>
				<td><code>❯ REPLACE-ME</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/tsconfig.json'>tsconfig.json</a></b></td>
				<td><code>❯ REPLACE-ME</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/tsconfig.app.json'>tsconfig.app.json</a></b></td>
				<td><code>❯ REPLACE-ME</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/angular.json'>angular.json</a></b></td>
				<td><code>❯ REPLACE-ME</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/.postcssrc.json'>.postcssrc.json</a></b></td>
				<td><code>❯ REPLACE-ME</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/package.json'>package.json</a></b></td>
				<td><code>❯ REPLACE-ME</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/nswag.json'>nswag.json</a></b></td>
				<td><code>❯ REPLACE-ME</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/AngularClient.esproj'>AngularClient.esproj</a></b></td>
				<td><code>❯ REPLACE-ME</code></td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/Dockerfile'>Dockerfile</a></b></td>
				<td><code>❯ REPLACE-ME</code></td>
			</tr>
			</table>
			<details>
				<summary><b>src</b></summary>
				<blockquote>
					<table>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/styles.scss'>styles.scss</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/main.ts'>main.ts</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/index.html'>index.html</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					</table>
					<details>
						<summary><b>app</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/app.component.scss'>app.component.scss</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/app.routes.ts'>app.routes.ts</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/app.component.spec.ts'>app.component.spec.ts</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/app.component.ts'>app.component.ts</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/app.config.ts'>app.config.ts</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/web-api-client.ts'>web-api-client.ts</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/app.component.html'>app.component.html</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
							<details>
								<summary><b>shared</b></summary>
								<blockquote>
									<details>
										<summary><b>modules</b></summary>
										<blockquote>
											<details>
												<summary><b>tree</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/modules/tree/tree.module.ts'>tree.module.ts</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/modules/tree/tree.model.ts'>tree.model.ts</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/modules/tree/tree.interface.ts'>tree.interface.ts</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
													<details>
														<summary><b>tree</b></summary>
														<blockquote>
															<table>
															<tr>
																<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/modules/tree/tree/tree.component.ts'>tree.component.ts</a></b></td>
																<td><code>❯ REPLACE-ME</code></td>
															</tr>
															<tr>
																<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/modules/tree/tree/tree.component.css'>tree.component.css</a></b></td>
																<td><code>❯ REPLACE-ME</code></td>
															</tr>
															<tr>
																<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/modules/tree/tree/tree.component.html'>tree.component.html</a></b></td>
																<td><code>❯ REPLACE-ME</code></td>
															</tr>
															</table>
														</blockquote>
													</details>
												</blockquote>
											</details>
										</blockquote>
									</details>
									<details>
										<summary><b>resolver</b></summary>
										<blockquote>
											<table>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/resolver/clear-state.resolver.ts'>clear-state.resolver.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											</table>
										</blockquote>
									</details>
									<details>
										<summary><b>directives</b></summary>
										<blockquote>
											<table>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/directives/directives.module.ts'>directives.module.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/directives/only-dialog.directive.ts'>only-dialog.directive.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/directives/scroll-to-invalide.directive.ts'>scroll-to-invalide.directive.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/directives/close-dialog.directive.ts'>close-dialog.directive.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/directives/resize-watcher.directive.ts'>resize-watcher.directive.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/directives/column-mode.directive.ts'>column-mode.directive.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											</table>
										</blockquote>
									</details>
									<details>
										<summary><b>models</b></summary>
										<blockquote>
											<table>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/models/entity-state.ts'>entity-state.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											</table>
										</blockquote>
									</details>
									<details>
										<summary><b>services</b></summary>
										<blockquote>
											<table>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/services/cache.service.ts'>cache.service.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/services/dialog.service.ts'>dialog.service.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/services/toast.service.ts'>toast.service.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											</table>
										</blockquote>
									</details>
									<details>
										<summary><b>enums</b></summary>
										<blockquote>
											<table>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/enums/view-mode.enum.ts'>view-mode.enum.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/enums/taost-type.enum.ts'>taost-type.enum.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/shared/enums/entity-type.enum.ts'>entity-type.enum.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											</table>
										</blockquote>
									</details>
								</blockquote>
							</details>
							<details>
								<summary><b>pages</b></summary>
								<blockquote>
									<details>
										<summary><b>problems</b></summary>
										<blockquote>
											<table>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem-tree.service.ts'>problem-tree.service.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problems.component.ts'>problems.component.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem.service.ts'>problem.service.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problems.module.ts'>problems.module.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem-category.service.ts'>problem-category.service.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem-catalog.service.ts'>problem-catalog.service.ts</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											<tr>
												<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problems.component.html'>problems.component.html</a></b></td>
												<td><code>❯ REPLACE-ME</code></td>
											</tr>
											</table>
											<details>
												<summary><b>problems-list</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problems-list/problems-list.component.ts'>problems-list.component.ts</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problems-list/problems-list.component.html'>problems-list.component.html</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problems-list/problems-list.component.css'>problems-list.component.css</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>problem</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem/problem.component.ts'>problem.component.ts</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem/problem.component.html'>problem.component.html</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem/problem.component.css'>problem.component.css</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>problem-catalog</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem-catalog/problem-catalog.component.css'>problem-catalog.component.css</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem-catalog/problem-catalog.component.html'>problem-catalog.component.html</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem-catalog/problem-catalog.component.ts'>problem-catalog.component.ts</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>state-management</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/state-management/problems.reducer.ts'>problems.reducer.ts</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/state-management/problems.selectors.ts'>problems.selectors.ts</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/state-management/problems.actions.ts'>problems.actions.ts</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>problem-category</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem-category/problem-category.component.css'>problem-category.component.css</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem-category/problem-category.component.ts'>problem-category.component.ts</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/src/app/pages/problems/problem-category/problem-category.component.html'>problem-category.component.html</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
										</blockquote>
									</details>
								</blockquote>
							</details>
						</blockquote>
					</details>
				</blockquote>
			</details>
			<details>
				<summary><b>public</b></summary>
				<blockquote>
					<table>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/AngularClient/public/manifest.webmanifest'>manifest.webmanifest</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					</table>
				</blockquote>
			</details>
		</blockquote>
	</details>
	<details> <!-- Kong Submodule -->
		<summary><b>Kong</b></summary>
		<blockquote>
			<details>
				<summary><b>declarative</b></summary>
				<blockquote>
					<table>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/Kong/declarative/kong.yml'>kong.yml</a></b></td>
						<td><code>Kong declarative configuration file</code></td>
					</tr>
					</table>
				</blockquote>
			</details>
			<details>
				<summary><b>config</b></summary>
				<blockquote>
					<table>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/Kong/config/kong.conf'>kong.conf</a></b></td>
						<td><code>Kong configuration file</code></td>
					</tr>
					</table>
				</blockquote>
			</details>
		</blockquote>
	</details>
	<details> <!-- WebApi Submodule -->
		<summary><b>WebApi</b></summary>
		<blockquote>
			<details>
				<summary><b>WebApi</b></summary>
				<blockquote>
					<table>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/ConfigureServices.cs'>ConfigureServices.cs</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/appsettings.Production.json'>appsettings.Production.json</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/appsettings.Development.json'>appsettings.Development.json</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/appsettings.json'>appsettings.json</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/Program.cs'>Program.cs</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/nswag.json'>nswag.json</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/WebApi.csproj'>WebApi.csproj</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/Dockerfile'>Dockerfile</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					</table>
					<details>
						<summary><b>Controllers</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/Controllers/ProblemCatalogsController.cs'>ProblemCatalogsController.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/Controllers/ProblemCategoriesController.cs'>ProblemCategoriesController.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/Controllers/ProblemsController.cs'>ProblemsController.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/Controllers/ApiControllerBase.cs'>ApiControllerBase.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
					<details>
						<summary><b>.config</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/.config/dotnet-tools.json'>dotnet-tools.json</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
					<details>
						<summary><b>Properties</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/Properties/launchSettings.json'>launchSettings.json</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
					<details>
						<summary><b>Filters</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/WebApi/Filters/ApiExceptionFilterAttribute.cs'>ApiExceptionFilterAttribute.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
				</blockquote>
			</details>
			<details>
				<summary><b>Application</b></summary>
				<blockquote>
					<table>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/ConfigureServices.cs'>ConfigureServices.cs</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application.csproj'>Application.csproj</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					</table>
					<details>
						<summary><b>Application</b></summary>
						<blockquote>
							<details>
								<summary><b>ProblemCatalogs</b></summary>
								<blockquote>
									<details>
										<summary><b>Queries</b></summary>
										<blockquote>
											<details>
												<summary><b>GetProblemCatalogsFiltered</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCatalogs/Queries/GetProblemCatalogsFiltered/GetProblemCatalogsFilteredQuery.cs'>GetProblemCatalogsFilteredQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>GetProblemCatalogById</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCatalogs/Queries/GetProblemCatalogById/GetProblemCatalogByIdQueryValidator.cs'>GetProblemCatalogByIdQueryValidator.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCatalogs/Queries/GetProblemCatalogById/GetProblemCatalogByIdQuery.cs'>GetProblemCatalogByIdQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>GetAllProblemCatalogs</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCatalogs/Queries/GetAllProblemCatalogs/GetAllProblemCatalogsQuery.cs'>GetAllProblemCatalogsQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>GetProblemCatalogSuggestions</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCatalogs/Queries/GetProblemCatalogSuggestions/GetProblemCatalogSuggestionsQuery.cs'>GetProblemCatalogSuggestionsQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
										</blockquote>
									</details>
									<details>
										<summary><b>Commands</b></summary>
										<blockquote>
											<details>
												<summary><b>CreateProblemCatalog</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCatalogs/Commands/CreateProblemCatalog/CreateProblemCatalogCommandValidator.cs'>CreateProblemCatalogCommandValidator.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCatalogs/Commands/CreateProblemCatalog/CreateProblemCatalogCommand.cs'>CreateProblemCatalogCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>UpdateProblemCatalog</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCatalogs/Commands/UpdateProblemCatalog/UpdateProblemCatalogCommandValidator.cs'>UpdateProblemCatalogCommandValidator.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCatalogs/Commands/UpdateProblemCatalog/UpdateProblemCatalogCommand.cs'>UpdateProblemCatalogCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>DeleteProblemCatalogs</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCatalogs/Commands/DeleteProblemCatalogs/DeleteProblemCatalogsCommand.cs'>DeleteProblemCatalogsCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>DeleteProblemCatalog</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCatalogs/Commands/DeleteProblemCatalog/DeleteProblemCatalogCommand.cs'>DeleteProblemCatalogCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
										</blockquote>
									</details>
								</blockquote>
							</details>
							<details>
								<summary><b>Problems</b></summary>
								<blockquote>
									<details>
										<summary><b>Queries</b></summary>
										<blockquote>
											<details>
												<summary><b>GetProblemById</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Queries/GetProblemById/GetProblemByIdQuery.cs'>GetProblemByIdQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Queries/GetProblemById/GetProblemByIdQueryValidator.cs'>GetProblemByIdQueryValidator.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>GetProblemsByCategory</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Queries/GetProblemsByCategory/GetProblemsByCategoryQuery.cs'>GetProblemsByCategoryQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>GetProblemSuggestions</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Queries/GetProblemSuggestions/GetProblemSuggestionsQuery.cs'>GetProblemSuggestionsQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>GetProblemsFiltered</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Queries/GetProblemsFiltered/GetProblemsFilteredQueryValidator.cs'>GetProblemsFilteredQueryValidator.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Queries/GetProblemsFiltered/GetProblemsFilteredQuery.cs'>GetProblemsFilteredQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>GetAllProblemCatalogs</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Queries/GetAllProblemCatalogs/GetProblemCatalogsQuery.cs'>GetProblemCatalogsQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>GetAllProblems</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Queries/GetAllProblems/GetAllProblemsQuery.cs'>GetAllProblemsQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
										</blockquote>
									</details>
									<details>
										<summary><b>Commands</b></summary>
										<blockquote>
											<details>
												<summary><b>DeleteProblems</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Commands/DeleteProblems/DeleteProblemsCommand.cs'>DeleteProblemsCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>DeleteProblem</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Commands/DeleteProblem/DeleteProblemCommand.cs'>DeleteProblemCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>CreateProblem</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Commands/CreateProblem/CreateProblemCommand.cs'>CreateProblemCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Commands/CreateProblem/CreateProblemCommandValidator.cs'>CreateProblemCommandValidator.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>UpdateProblem</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Commands/UpdateProblem/UpdateProblemCommandValidator.cs'>UpdateProblemCommandValidator.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/Problems/Commands/UpdateProblem/UpdateProblemCommand.cs'>UpdateProblemCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
										</blockquote>
									</details>
								</blockquote>
							</details>
							<details>
								<summary><b>ProblemCategories</b></summary>
								<blockquote>
									<details>
										<summary><b>Queries</b></summary>
										<blockquote>
											<details>
												<summary><b>GetAllProblemCategories</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCategories/Queries/GetAllProblemCategories/GetAllProblemCategoriesQuery.cs'>GetAllProblemCategoriesQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>GetProblemCategoryById</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCategories/Queries/GetProblemCategoryById/GetProblemCategoryByIdQueryValidator.cs'>GetProblemCategoryByIdQueryValidator.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCategories/Queries/GetProblemCategoryById/GetProblemCategoryByIdQuery.cs'>GetProblemCategoryByIdQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>GetProblemCategoriesFiltered</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCategories/Queries/GetProblemCategoriesFiltered/GetProblemCategoriesFilteredQuery.cs'>GetProblemCategoriesFilteredQuery.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
										</blockquote>
									</details>
									<details>
										<summary><b>Commands</b></summary>
										<blockquote>
											<details>
												<summary><b>DeleteProblemCategory</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCategories/Commands/DeleteProblemCategory/DeleteProblemCategoryCommand.cs'>DeleteProblemCategoryCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>DeleteProblemCategories</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCategories/Commands/DeleteProblemCategories/DeleteProblemCategoriesCommand.cs'>DeleteProblemCategoriesCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>CreateProblemCategory</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCategories/Commands/CreateProblemCategory/CreateProblemCategoryCommandValidator.cs'>CreateProblemCategoryCommandValidator.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCategories/Commands/CreateProblemCategory/CreateProblemCategoryCommand.cs'>CreateProblemCategoryCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
											<details>
												<summary><b>UpdateProblemCategory</b></summary>
												<blockquote>
													<table>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCategories/Commands/UpdateProblemCategory/UpdateProblemCategoryCommand.cs'>UpdateProblemCategoryCommand.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													<tr>
														<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Application/ProblemCategories/Commands/UpdateProblemCategory/UpdateProblemCategoryCommandValidator.cs'>UpdateProblemCategoryCommandValidator.cs</a></b></td>
														<td><code>❯ REPLACE-ME</code></td>
													</tr>
													</table>
												</blockquote>
											</details>
										</blockquote>
									</details>
								</blockquote>
							</details>
						</blockquote>
					</details>
					<details>
						<summary><b>Common</b></summary>
						<blockquote>
							<details>
								<summary><b>Exceptions</b></summary>
								<blockquote>
									<table>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/Exceptions/ForbiddenAccessException.cs'>ForbiddenAccessException.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/Exceptions/ValidationException.cs'>ValidationException.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/Exceptions/NotFoundException.cs'>NotFoundException.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									</table>
								</blockquote>
							</details>
							<details>
								<summary><b>Models</b></summary>
								<blockquote>
									<table>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/Models/Result.cs'>Result.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									</table>
								</blockquote>
							</details>
							<details>
								<summary><b>Behaviours</b></summary>
								<blockquote>
									<table>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/Behaviours/UnhandledExceptionBehaviour.cs'>UnhandledExceptionBehaviour.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/Behaviours/ValidationBehaviour.cs'>ValidationBehaviour.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									</table>
								</blockquote>
							</details>
							<details>
								<summary><b>DTOs</b></summary>
								<blockquote>
									<table>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/DTOs/ProblemCategoriesDto.cs'>ProblemCategoriesDto.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/DTOs/ProblemCategoryDto.cs'>ProblemCategoryDto.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/DTOs/ProblemCatalogDto.cs'>ProblemCatalogDto.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/DTOs/ProblemDto.cs'>ProblemDto.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									</table>
								</blockquote>
							</details>
							<details>
								<summary><b>Mappings</b></summary>
								<blockquote>
									<table>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/Mappings/MappingProfile.cs'>MappingProfile.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/Mappings/IMapFrom.cs'>IMapFrom.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									</table>
								</blockquote>
							</details>
							<details>
								<summary><b>Interfaces</b></summary>
								<blockquote>
									<table>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Application/Common/Interfaces/IApplicationDbContext.cs'>IApplicationDbContext.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									</table>
								</blockquote>
							</details>
						</blockquote>
					</details>
				</blockquote>
			</details>
			<details>
				<summary><b>Persistence</b></summary>
				<blockquote>
					<table>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/ConfigureServices.cs'>ConfigureServices.cs</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Persistence.csproj'>Persistence.csproj</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					</table>
					<details>
						<summary><b>Migrations</b></summary>
						<blockquote>
							<details>
								<summary><b>Application</b></summary>
								<blockquote>
									<table>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Migrations/Application/20250421135952_Initial.Designer.cs'>20250421135952_Initial.Designer.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Migrations/Application/ApplicationDbContextModelSnapshot.cs'>ApplicationDbContextModelSnapshot.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Migrations/Application/20250421135952_Initial.cs'>20250421135952_Initial.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									</table>
								</blockquote>
							</details>
						</blockquote>
					</details>
					<details>
						<summary><b>Configurations</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Configurations/ProblemConfiguration.cs'>ProblemConfiguration.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Configurations/ProblemCatalogConfiguration.cs'>ProblemCatalogConfiguration.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Configurations/ProblemCategoryConfiguration.cs'>ProblemCategoryConfiguration.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
					<details>
						<summary><b>Common</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Common/MediatorExtensions.cs'>MediatorExtensions.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Common/DesignTimeFactory.cs'>DesignTimeFactory.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
					<details>
						<summary><b>Interceptors</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Interceptors/AuditableEntitySaveChangesInterceptor.cs'>AuditableEntitySaveChangesInterceptor.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Interceptors/DispatchDomainEventsInterceptor.cs'>DispatchDomainEventsInterceptor.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
					<details>
						<summary><b>Initialization</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Initialization/ApplicationDbContextInitialiser.cs'>ApplicationDbContextInitialiser.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
					<details>
						<summary><b>Context</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Persistence/Context/ApplicationDbContext.cs'>ApplicationDbContext.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
				</blockquote>
			</details>
			<details>
				<summary><b>Domain</b></summary>
				<blockquote>
					<table>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/Domain.csproj'>Domain.csproj</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/GlobalUsings.cs'>GlobalUsings.cs</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					</table>
					<details>
						<summary><b>Enums</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/Enums/ClaimValue.cs'>ClaimValue.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/Enums/UserRoles.cs'>UserRoles.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/Enums/EntityType.cs'>EntityType.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
					<details>
						<summary><b>IdentityEntities</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/IdentityEntities/IApplicationRoleClaim.cs'>IApplicationRoleClaim.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/IdentityEntities/IApplicationRole.cs'>IApplicationRole.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/IdentityEntities/IApplicationUser.cs'>IApplicationUser.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
					<details>
						<summary><b>Common</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/Common/ValueObject.cs'>ValueObject.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/Common/BaseEntity.cs'>BaseEntity.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/Common/BaseEvent.cs'>BaseEvent.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/Common/BaseAuditableEntity.cs'>BaseAuditableEntity.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
					<details>
						<summary><b>Entities</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/Entities/ProblemCatalog.cs'>ProblemCatalog.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/Entities/Problem.cs'>Problem.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Domain/Entities/ProblemCategory.cs'>ProblemCategory.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
						</blockquote>
					</details>
				</blockquote>
			</details>
			<details>
				<summary><b>Infrastructure</b></summary>
				<blockquote>
					<table>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Infrastructure/Infrastructure.csproj'>Infrastructure.csproj</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					<tr>
						<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Infrastructure/ConfigureServices.cs'>ConfigureServices.cs</a></b></td>
						<td><code>❯ REPLACE-ME</code></td>
					</tr>
					</table>
					<details>
						<summary><b>Common</b></summary>
						<blockquote>
							<table>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Infrastructure/Common/DnsHandler.cs'>DnsHandler.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							<tr>
								<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Infrastructure/Common/OpenIdConfigurationService.cs'>OpenIdConfigurationService.cs</a></b></td>
								<td><code>❯ REPLACE-ME</code></td>
							</tr>
							</table>
							<details>
								<summary><b>Behaviours</b></summary>
								<blockquote>
									<table>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Infrastructure/Common/Behaviours/PerformanceBehaviour.cs'>PerformanceBehaviour.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									<tr>
										<td><b><a href='https://github.com/aekoky/CleanArchitecture/blob/master/WebApi/Infrastructure/Common/Behaviours/LoggingBehaviour.cs'>LoggingBehaviour.cs</a></b></td>
										<td><code>❯ REPLACE-ME</code></td>
									</tr>
									</table>
								</blockquote>
							</details>
						</blockquote>
					</details>
				</blockquote>
			</details>
		</blockquote>
	</details>
</details>

---
##  Getting Started

###  Prerequisites

Before getting started with CleanArchitecture, ensure your runtime environment meets the following requirements:

✅ Prerequisites
Make sure you have Docker installed:

###  Installation

Install CleanArchitecture using one of the following methods:

**Build from source:**

1. Clone the CleanArchitecture repository:
```sh
❯ git clone https://github.com/aekoky/CleanArchitecture
```

2. Navigate to the project directory:
```sh
❯ cd CleanArchitecture
```

⚙️ Build & Run with Docker
```sh
❯ docker-compose up --build
```

This will:

Build and start the .NET Core API

Serve the Angular frontend

Spin up a PostgreSQL database

Start Kong Gateway for routing and API management

🌐 Access the App
Frontend: http://localhost

API: http://localhost/api

Kong Gateway: http://localhost:8000

Kong Admin UI: http://localhost:8001

---
##  Project Roadmap

- [X] **`Task 1`**: <strike>Implement feature one.</strike>
- [ ] **`Task 2`**: Implement Auth.
- [ ] **`Task 3`**: Implement Multi tenant.

---

##  Contributing

- **💬 [Join the Discussions](https://github.com/aekoky/CleanArchitecture/discussions)**: Share your insights, provide feedback, or ask questions.
- **🐛 [Report Issues](https://github.com/aekoky/CleanArchitecture/issues)**: Submit bugs found or log feature requests for the `CleanArchitecture` project.
- **💡 [Submit Pull Requests](https://github.com/aekoky/CleanArchitecture/blob/main/CONTRIBUTING.md)**: Review open PRs, and submit your own PRs.

<details closed>
<summary>Contributing Guidelines</summary>

1. **Fork the Repository**: Start by forking the project repository to your github account.
2. **Clone Locally**: Clone the forked repository to your local machine using a git client.
   ```sh
   git clone https://github.com/aekoky/CleanArchitecture
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to github**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.
8. **Review**: Once your PR is reviewed and approved, it will be merged into the main branch. Congratulations on your contribution!
</details>

<details closed>
<summary>Contributor Graph</summary>
<br>
<p align="left">
   <a href="https://github.com{/aekoky/CleanArchitecture/}graphs/contributors">
      <img src="https://contrib.rocks/image?repo=aekoky/CleanArchitecture">
   </a>
</p>
</details>

---

##  Acknowledgments

- List any resources, contributors, inspiration, etc. here.

---