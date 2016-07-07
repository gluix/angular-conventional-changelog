Usage (build changelog)
===============
-o, --out             Required. Path to the output-file.

-r, --repository      Required. Path to the git repository to process.

-t, --filter-type     (Default: System.String[]) Filter commits by type(s).

-s, --filter-scope    (Default: System.String[]) Filter commits by scope(s).

--since               A pointer to a commit object or a list of pointers to
                      consider as starting points.

--until               A pointer to a commit object or a list of pointers
                      which will be excluded (along with ancestors) from the
                      enumeration.

--help                Display the help screen.



Commit messages (karma-convention)
===============

### The reasons for these conventions

* automatic generating of the changelog
* simple navigation through git history (eg. ignoring style changes)

### Format of the commit message

    <type>(<scope>): <subject>

    <body>

    <footer>
    
### Message subject (first line)

First line cannot be longer than 70 characters, second line is always blank and other lines should be wrapped at 80 characters. The type and scope should always be lowercase as shown below.

**Allowed `<type>` values:**

* feat (new feature)
* fix (bug fix)
* docs (changes to documentation)
* style (formatting, missing semi colons, etc; no code change)
* refactor (refactoring production code)
* test (adding missing tests, refactoring tests; no production code change)
* chore (updating grunt tasks etc; no production code change)

**Example `<scope>` values:**

* init
* runner
* watcher
* config
* web-server
* proxy
* etc.

The `<scope>` can be empty (eg. if the change is a global or difficult to assign to a single component), in which case the parentheses are omitted. In smaller projects such as Karma plugins, the <scope> is empty.

### Message body

* uses the imperative, present tense: “change” not “changed” nor “changes”
* includes motivation for the change and contrasts with previous behavior

For more info about message body, see:

* http://365git.tumblr.com/post/3308646748/writing-git-commit-messages
* http://tbaggery.com/2008/04/19/a-note-about-git-commit-messages.html

### Message footer

**Referencing issues**

Closed issues should be listed on a separate line in the footer prefixed with "Closes" keyword like this:

    Closes #234
    
or in case of multiple issues:

    Closes #123, #245, #992
    
**Breaking changes**

All breaking changes have to be mentioned in footer with the description of the change, justification and migration notes.

    BREAKING CHANGE:

    `port-runner` command line option has changed to `runner-port`, so that it is
    consistent with the configuration file syntax.

    To migrate your project, change all the commands, where you use `--port-runner`
    to `--runner-port`.
    
    
Commit message conventions based on [Karma Git Commit Msg Convention](http://karma-runner.github.io/0.10/dev/git-commit-msg.html)
