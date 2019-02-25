// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  appName: 'dating',
  version: '2.0',
  production: false,
  isMockEnabled: false, // You have to switch this, when your real back-end is done
  api: {
    default: 'http://localhost:44396/api',
    v2: {
      baseUrl: 'http://localhost:44396'
    },
  }
};
