import java.util.*;
import java.lang.reflect.Array;

class Main {
    public static void main(String[] args) throws Exception {
        String input = new String(System.in.readAllBytes(), java.nio.charset.StandardCharsets.UTF_8);
        String[] lines = input.split("\n", -1);
        int[] nums = (int[]) convert(parseJson(lines[0]), int[].class);
        int target = (int) convert(parseJson(lines[1]), int.class);
        var result = new Solution().twoSum(nums, target);
        System.out.println(toJson(result));
    }

    // --- Embedded dependency-free JSON (scalars + nested arrays only) ---------

    static int p;
    static String s;

    static Object parseJson(String str) {
        s = str;
        p = 0;
        return parseValue();
    }

    static Object parseValue() {
        skipWs();
        char c = s.charAt(p);
        if (c == '[') return parseArray();
        if (c == '"') return parseString();
        if (c == 't' || c == 'f') return parseBool();
        if (c == 'n') { p += 4; return null; }
        return parseNumber();
    }

    static void skipWs() {
        while (p < s.length() && Character.isWhitespace(s.charAt(p))) p++;
    }

    static List<Object> parseArray() {
        List<Object> list = new ArrayList<>();
        p++; // consume '['
        skipWs();
        if (s.charAt(p) == ']') { p++; return list; }
        while (true) {
            list.add(parseValue());
            skipWs();
            char c = s.charAt(p++);
            if (c == ']') break;
            skipWs();
        }
        return list;
    }

    static String parseString() {
        StringBuilder sb = new StringBuilder();
        p++; // consume opening quote
        while (true) {
            char c = s.charAt(p++);
            if (c == '"') break;
            if (c == '\\') {
                char e = s.charAt(p++);
                switch (e) {
                    case 'n': sb.append('\n'); break;
                    case 't': sb.append('\t'); break;
                    case 'r': sb.append('\r'); break;
                    case 'b': sb.append('\b'); break;
                    case 'f': sb.append('\f'); break;
                    case 'u':
                        sb.append((char) Integer.parseInt(s.substring(p, p + 4), 16));
                        p += 4;
                        break;
                    default: sb.append(e);
                }
            } else {
                sb.append(c);
            }
        }
        return sb.toString();
    }

    static Boolean parseBool() {
        if (s.charAt(p) == 't') { p += 4; return Boolean.TRUE; }
        p += 5;
        return Boolean.FALSE;
    }

    static Object parseNumber() {
        int start = p;
        while (p < s.length() && "+-0123456789.eE".indexOf(s.charAt(p)) >= 0) p++;
        String num = s.substring(start, p);
        if (num.indexOf('.') >= 0 || num.indexOf('e') >= 0 || num.indexOf('E') >= 0) {
            return Double.parseDouble(num);
        }
        return Long.parseLong(num);
    }

    @SuppressWarnings("unchecked")
    static Object convert(Object o, Class<?> t) {
        if (t.isArray()) {
            Class<?> ct = t.getComponentType();
            List<Object> a = (List<Object>) o;
            Object arr = Array.newInstance(ct, a.size());
            for (int i = 0; i < a.size(); i++) Array.set(arr, i, convert(a.get(i), ct));
            return arr;
        }
        if (t == int.class) return ((Number) o).intValue();
        if (t == long.class) return ((Number) o).longValue();
        if (t == double.class) return ((Number) o).doubleValue();
        if (t == boolean.class) return o;
        if (t == char.class) return ((String) o).charAt(0);
        return o; // String
    }

    static String toJson(Object o) {
        if (o == null) return "null";
        if (o instanceof String || o instanceof Character) return quote(o.toString());
        if (o instanceof Boolean || o instanceof Number) return String.valueOf(o);
        if (o.getClass().isArray()) {
            StringBuilder sb = new StringBuilder("[");
            int n = Array.getLength(o);
            for (int i = 0; i < n; i++) {
                if (i > 0) sb.append(",");
                sb.append(toJson(Array.get(o, i)));
            }
            return sb.append("]").toString();
        }
        return quote(o.toString());
    }

    static String quote(String str) {
        StringBuilder sb = new StringBuilder("\"");
        for (int i = 0; i < str.length(); i++) {
            char c = str.charAt(i);
            if (c == '"' || c == '\\') sb.append('\\').append(c);
            else if (c == '\n') sb.append("\\n");
            else if (c == '\t') sb.append("\\t");
            else if (c == '\r') sb.append("\\r");
            else sb.append(c);
        }
        return sb.append("\"").toString();
    }
}
