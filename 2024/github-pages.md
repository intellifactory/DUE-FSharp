# Setting up auto-deploy to `gh-pages`

## Step 1. Adding `.github/workflow/ghpages.yml`

This file (copy it from [SPASandbox:ghpages.yml](https://github.com/intellifactory/DUE-FSharp-SPASandbox-2024/blob/master/.github/workflows/ghpages.yml)) is responsible for telling GitHub to automatically deploy your app to the `gh_pages` branch each time you commit.

Be sure to correctly set:

 * The input branch name you use - `master` (default) vs `main` - in the `on:push:branches` section.
 * Your username in the `dotnet nuget add source` command
 * The `WEBSHARPER_FEED` repository secret - see Step 2.

## Step 2. Configuring `WEBSHARPER_FEED`

1. Configure a Personal Access Token (PAT) on your GitHub user's Settings page, under Developer Settings, Tokens (classic) - "Generate New Token",  classic token.
2. Set a note, so you remember what this token was created for, for example "WebSharper developer feed".
3. Set your expiration timeframe. The token will only work within this time period.
4. Under "Scopes", check "`read:packages`".
5. Click "Generate token", and be sure to copy it to your clipboard or save it elsewhere for the next steps.
6. Now, head over to your repo's Setting page, click "Secrets and variables", then Actions.
7. Create a new repository secret by clicking "New repository secret" - for the name, use `WEBSHARPER_FEED` (or else change this in the deploy script), and for the value, paste in your PAT from Step 5.

## Step 3. Trigger the auto-deploy action

If you set everything up correctly, if you make a new commit, it should kick off a new build+deployment run, which you can see under the Actions main tab of your respository. Make sure it succeeds, if it fails, check the error(s) and fix accordingly.

## Step 4. Selecting `gh_pages` in Settings/Pages/Branch

Once the action succeeds, you should have a `gh-pages` branch in your repository. At that point, go to your repository's Settings page, select Pages on the left, and set the "Branch" dropdown to `gh-pages`, then hit Save.

At this point, you should be able to go to:

`https://<your-username>.github.io/<your-repository>`

... and see your SPA up and running.

# Troubleshooting

## I see my README on the deployment site
 
This means that you didn't set the `gh_pages` branch in Step 4 above. If it points to your `master`/`main` branch, it will serve the README instead.

## I get an empty page

1. Make sure that you include the generated JS file using `type="module"` and not `type="text/javascript` in your HTML template.

2. Make sure you correctly reference this generated JS (check that it exists on your local build, obviously).
