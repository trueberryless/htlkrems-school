## Get repo size

Open `wsl` under windows:

```bash
curl -s -H "Authorization: token GITHUB_API_TOKEN" https://api.github.com/repos/trueberryless/htlkrems-school | jq '.size' | numfmt --to=iec --from-unit=1024
```

![Static Badge](https://img.shields.io/badge/%3C!--%20REPO_SIZE%20--%3E?label=repo%20size)
