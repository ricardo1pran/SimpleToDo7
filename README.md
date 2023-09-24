# Simple ToDo7
![SimpleToDo7Logo](images/ToDoSeven.png)

<i>Simple ToDo7 Logo, the 7 is inspired from Microsoft To-Do logo</i>

Simple ToDo7 is a To-Do Application made natively for Windows 7. The main purpose is to help you have a handy yet simple to-do application for your Windows 7 environtment. The second purpose is to help inspire new or learner programmers to study or create a simple yet useful utility applications.

(Note: See screenshots below)

## Background

I'm currently having nostalgic moments by installing old operating systems in a Virtual Machine and using them as my daily OS. While using Windows Vista, I created "ToDo Vista" which you can see [here](https://github.com/ricardo1pran/ToDoVista). After a while in Windows Vista exploring the features I've known and neven known before, it's time for me to move to Windows 7. But now I feel incomplete, and wanted to improve my ToDo Vista better. But because now I'm using Windows 7, it's time to create the better version as a separate application.

## Features

I call a task in this application as a "ToDo". Anything mentioned as "ToDo" inside the app, means the task. There are features that's already exist in ToDo Vista tho, so I'll make the features that only available in Simple ToDo7 as italic. See the list of the features below:

- Add ToDo
- Complete ToDo
- Delete ToDo
- <i>Edit existing ToDo</i>
- Save ToDo list to a .txt file
- <i>Clear existing ToDo list</i>
- <i>Move ToDo items in the list up and down</i>
- <i>A simple How To Guide in Help context menu</i>
- <i>See completed ToDo as separate list</i> (planned feature!)
- <i>Set in-app preferences</i> (using WinForms Settings feature)
- <i>Aero glass integration</i> (Planned feature! But still figuring out for WinForms, instructions online are for WPF)

<i>Preferences Features:</i>
- Show/Hide ToDos related alerts (such as alerts for completing, deleting ToDos, etc.)
- Show/Hide exit confirmation (careful!)
- Auto Move completed ToDo <i>(this is upcoming planned feature, needs "Completed ToDos" form to be done first)</i>
- Allow uncomplete / Edit completed ToDos (by default, completed ToDos can't be edited, to prevent the task being incomplete again) (editing completed ToDos means setting them as an incomplete (active) ToDo and can be re-completed again).

## Technical Requirements

There are no specific requirements for this application, I believe it will run on Windows 7 and newer machines, so I'll just mention the tools I used to create this application.

- Microsoft Visual C# Express 2010 (WinForms)
- Microsoft .NET 4.0 - 4.5

## Application Support and Updates

I'll still be in Windows 7 operating system until September 2023, so expect the "upcoming" features to be done before September 30th. After that I'll move to Windows 8.1, and maybe create a newer modern ToDo application, or keep maintaining this ToDo in Windows 8.1 environtment.

### Update Sep 24th, 2023
All upcoming features that is planned will be implemented soon but no exact date (expect late 2023 - early 2024). And because my primary OS is Linux and I'm enjoying myself creating ToDo apps, I will try to create the Linux version of this using Qt or whatever I decide later.

## Usage

As stated on the license I chose. Plus you're free to contact me [here](contact@ricardogunawan.com) if you think you want to use my apps for other purposes, or even want to help me making this app better :) . Usage for study purposes and project starters are always welcome.

## Screenshots

![todo](images/1.png)<br/>
<i>Simple ToDo7 Main App View</i>

![todo](images/2complete.png)<br/>
<i>Simple ToDo7 Complete a ToDo</i>

![todo](images/3edit.png)<br/>
<i>Simple ToDo7 edit a ToDo</i>

![todo](images/4del.png)<br/>
<i>Simple ToDo7 delete a ToDo</i>

![todo](images/5-1-save.png)<br/>
<i>Simple ToDo7 Save as menu</i>

![todo](images/5-2-save.png)<br/>
<i>Simple ToDo7 Save as dialog</i>

![todo](images/5-3-save.png)<br/>
<i>Simple ToDo7 saved .txt file</i>

![todo](images/6cls.png)<br/>
<i>Simple ToDo7 Clear ToDo (confirmation)</i>

![todo](images/pref1.png)<br/>
<i>Simple ToDo7 Preferences "General" tab

![todo](images/pref2.png)<br/>
<i>Simple ToDo7 Preferences "ToDos" tab

![todo](images/pref3.png)<br/>
<i>Simple ToDo7 Preferences "Export" tab

![todo](images/about2.png)<br/>
<i>Simple ToDo7 v.1.1.0 New Modern and Clean About (compared to ToDo Vista)</i>

## Changelogs
### v.1.1.0
Add some preferences. Now preferences could saved permanently. First time we have a Release!
### v.1.0.0
Initialize SimpleToDo7