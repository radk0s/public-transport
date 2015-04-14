package main

import (
	"fmt"
	"strings"
	"github.com/radk0s/public-transport/transport"
)

func main() {
	fmt.Printf("Hello world")

	tf := "3\n2 3 4\n3 6 8\n4 5 3\n5 3\n6 7 7"
    transport.LoadInput(strings.NewReader(tf))
}
