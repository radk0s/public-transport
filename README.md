# public-transport

### How to Write Go Code
https://golang.org/doc/code.html

### Directory structure
```
~/Documents/go_workspace $ tree -L 4
.
├── bin
│   └── public-transport <- build artifact
├── pkg
│   └── linux_amd64
│       └── github.com
│           └── radk0s
└── src
    └── github.com
        └── radk0s
            └── public-transport <- clone repository here

```

### Building
 1. set `GOPATH` to point to your *workspace*  
    `export GOPATH="$HOME/go_workspace"`
 2. type `go install github.com/radk0s/public-transport`  
    or just `go install` from repository root
