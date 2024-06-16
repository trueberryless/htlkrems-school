## Get repo size

Open `wsl` under windows:

```bash
curl -s -H "Authorization: token GITHUB_API_TOKEN" https://api.github.com/repos/trueberryless/htlkrems-school | jq '.size' | numfmt --to=iec --from-unit=1024
```

![GitHub repo size](https://img.shields.io/github/repo-size/trueberryless/htlkrems-school)
