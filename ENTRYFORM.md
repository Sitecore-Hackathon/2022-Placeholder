# Hackathon Submission Entry form

> __Important__  
> 
> Copy and paste the content of this file into README.md or face automatic __disqualification__  
> All headlines and subheadlines shall be retained if not noted otherwise.  
> Fill in text in each section as instructed and then delete the existing text, including this blockquote.

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

## Team name
Placeholder

## Category
1.	Build an e-commerce Minimum Viable Product to sell community t-shirts 

## Description
Our hackathon entry 

  - Module Purpose
  - What problem was solved (if any)
    - How does this module solve it

_You can alternately paste a [link here](#docs) to a document within this repo containing the description._

## Video link
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

⟹ [Replace this Video link](#video-link)



## Pre-requisites and Dependencies

⟹ Does your module rely on other Sitecore modules or frameworks?

- List any dependencies
- Or other modules that must be installed
- Or services that must be enabled/configured

_Remove this subsection if your entry does not have any prerequisites other than Sitecore_

## Installation instructions

1. Have a fresh Sitecore 10.2 environment.
2. Open dresscode.sln solution located at 2022-Placeholder\src
3. Rebuild Solution
4. Edit Publish profile for projects Dresscode.Project.Website and Dresscode.Feature.Content to deploy to your local sitecore installation, make sure debug mode is selected.
5. Publish Dresscode.Project.Website and Dresscode.Feature.Content projects
6. After publishing and site comes back install Sitecore Contetnt Package located at: , install this package with option merge=>clear
7. Full site publish
8. Go to Home 

### Configuration
⟹ If there are any custom configuration that has to be set manually then remember to add all details here.

_Remove this subsection if your entry does not require any configuration that is not fully covered in the installation instructions already_

## Usage instructions
To test the product listing that is located at the root folder, any changes which are done 
To test Sendmail the url for the checkout for is on {siteHostname}/Checkout. After filling up the form an email will be sent to the mail, (dont use outlook because it seems tpo be blocking these mails before reaching the spam folder)
To test The 

Include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](docs/images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://thiscatdoesnotexist.com/)

## Comments
If you'd like to make additional comments that is important for your module entry.
