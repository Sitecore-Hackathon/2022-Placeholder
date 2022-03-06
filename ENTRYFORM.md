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
The purpose of this submission is to show cool features and to demonstrate that beyond the e-commerce and mail features, we bring a proposal so that the sitecore comunity has the ability to create custom shirts based on special code snippets they love (Check the video!).


## Video link
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

⟹ [Replace this Video link](#video-link)



## Pre-requisites and Dependencies

All dependencies for this module should be isntalled during the projects publish action.

## Installation instructions

1. Have a fresh Sitecore 10.2 installation.
2. Open dresscode.sln solution located at 2022-Placeholder\src
3. Rebuild Solution
4. Edit Publish profile for projects Dresscode.Project.Website and Dresscode.Feature.Content to deploy to your local sitecore installation, make sure debug mode is selected.
5. Publish Dresscode.Project.Website and Dresscode.Feature.Content projects
6. After publishing and site comes back install the Sitecore Content Package located at: root (/Dresscode.zip) , install this package with option merge=>clear
7. Full site publish
8. Go to Home 

### Configuration
⟹ If there are any custom configuration that has to be set manually then remember to add all details here.

_Remove this subsection if your entry does not require any configuration that is not fully covered in the installation instructions already_

## Usage instructions
To test the product listing that is located at the root folder, any changes which are done 
To test Sendmail the url for the checkout for is on {siteHostname}/Checkout. After filling up the form an email will be sent to the mail, (dont use outlook because it seems tpo be blocking these mails before reaching the spam folder)
To test the Custom Shirt generator go to {siteHostname}/Product, follow the instructions as depicted on the video.



![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")


## Comments
For the application we hav tried to follow helix architecture and we have created wrappers for both OrderCloud and SendMail applciations, this wrappers are located unde project: Dresscode.Foundation.Services in the Solution.
